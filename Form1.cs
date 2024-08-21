using System;
using System.Windows.Forms;

namespace Simple_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Đăng ký sự kiện Click cho các nút số
            btn_0.Click += new EventHandler(NumberButton_Click);
            btn_1.Click += new EventHandler(NumberButton_Click);
            btn_2.Click += new EventHandler(NumberButton_Click);
            btn_3.Click += new EventHandler(NumberButton_Click);
            btn_4.Click += new EventHandler(NumberButton_Click);
            btn_5.Click += new EventHandler(NumberButton_Click);
            btn_6.Click += new EventHandler(NumberButton_Click);
            btn_7.Click += new EventHandler(NumberButton_Click);
            btn_8.Click += new EventHandler(NumberButton_Click);
            btn_9.Click += new EventHandler(NumberButton_Click);
            btn_Cham.Click += new EventHandler(NumberButton_Click);
            btn_Cong.Click += new EventHandler(Click_PhepTinh);
            btn_Tru.Click += new EventHandler(Click_PhepTinh);
            btn_Nhan.Click += new EventHandler(Click_PhepTinh);
            btn_Chia.Click += new EventHandler(Click_PhepTinh);
            btn_C.Click += new EventHandler(ClearButton_Click);
            btn_Bang.Click += new EventHandler(ClickButton_KetQua);
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button clickButton = sender as Button;

            bool check = false;
            if (clickButton == btn_Cham)
            {
                if (lbl_KetQua.Text == "0")
                {
                    lbl_KetQua.Text = "";
                    lbl_KetQua.Text = "0" + lbl_KetQua.Text;
                    check = true;
                }
            }

            if (clickButton != null)
            {
                if (lbl_KetQua.Text == "0" && check == false)
                {
                    lbl_KetQua.Text = "";
                }

                if (clickButton.Text == ".")
                {
                    lbl_KetQua.Text += ",";
                }
                else
                {
                    lbl_KetQua.Text += clickButton.Text;
                }
            }
        }

        private void ClearButton_Click(Object sender, EventArgs e)
        {
            lbl_KetQua.Text = "0";
            lbl_baiToan.Text = "";
        }

        private void Click_PhepTinh(Object sender, EventArgs e)
        {
            ClickButton_KetQua(sender, e);
            Button clickButton = sender as Button;
            lbl_baiToan.Text = "";
            lbl_baiToan.Text += lbl_KetQua.Text + " " + clickButton.Text;
            lbl_KetQua.Text = "0";
        }

        private void ClickButton_KetQua(Object sender, EventArgs e)
        {
            string BT = lbl_baiToan.Text;
            char[] operators = { '+', '-', 'x', '/' };
            int operatorIndex = BT.IndexOfAny(operators);
            if (operatorIndex != -1)
            {
                string afterOperator = BT.Substring(operatorIndex + 1).Trim();
                if (!string.IsNullOrEmpty(afterOperator))
                {
                    return;
                }
            }

            string numInLabel = lbl_baiToan.Text + lbl_KetQua.Text;
            string num1 = "", num2 = "";
            string phepTinh = "";

            try
            {
                if (numInLabel.Contains("+"))
                {
                    phepTinh += "+";
                    num1 = lbl_baiToan.Text.Split('+')[0];
                    num2 = lbl_KetQua.Text;
                }
                else if (numInLabel.Contains("-"))
                {
                    phepTinh += "-";
                    num1 = lbl_baiToan.Text.Split('-')[0];
                    num2 = lbl_KetQua.Text;
                }
                else if (numInLabel.Contains("x"))
                {
                    phepTinh += "*";
                    num1 = lbl_baiToan.Text.Split('x')[0];
                    num2 = lbl_KetQua.Text;
                }
                else if (numInLabel.Contains("/"))
                {
                    phepTinh += "/";
                    num1 = lbl_baiToan.Text.Split('/')[0];
                    num2 = lbl_KetQua.Text;
                }
                else
                {
                    //Chua biet
                }

                double SoThuNhat = double.Parse(num1);
                double SoThuHai = double.Parse(num2);
                double KetQua = 0;

                if (phepTinh == "+")
                {
                    KetQua = SoThuNhat + SoThuHai;
                    lbl_KetQua.Text = "" + KetQua;
                }
                else if (phepTinh == "-")
                {
                    KetQua = SoThuNhat - SoThuHai;
                    lbl_KetQua.Text = "" + KetQua;
                }
                else if (phepTinh == "*")
                {
                    KetQua = SoThuNhat * SoThuHai;
                    lbl_KetQua.Text = "" + KetQua;
                }
                else if (phepTinh == "/")
                {
                    if (SoThuHai == 0)
                    {
                        return;
                    }

                    KetQua = SoThuNhat / SoThuHai;
                    lbl_KetQua.Text = "" + KetQua;
                }
            }
            catch (Exception ex)
            {
                //Khong lam gi ca
            }

            lbl_baiToan.Text += " " + num2;
        }

        private void btn_CE_Click(object sender, EventArgs e)
        {
            string ketQua = lbl_KetQua.Text;
            if (ketQua != "")
            {
                ketQua = ketQua.Substring(0, ketQua.Length - 1);
                if (ketQua == "")
                {
                    ketQua = "0";
                }

                lbl_KetQua.Text = ketQua;

            }
        }
    }
}
//Bat dau: 11/07/2024 - Ket thuc: 12/07/2010