using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private double Number1 = 0, Number2 = 0;

        private char Sign = ' ';

        private bool Alert = false;

        private string Equasion = "";

        private void ClearAll()
        {
            textBox1.Text = "";
            maskedTextBox1.Text = "";
            Equasion = "";
            Number1 = 0;
            Number2 = 0;
            Sign = ' ';
            Alert = false;
        }

        private bool NotEmptyCheck()
        {
            if ((textBox1.Text == "") || (textBox1.Text == ","))
                return false;
            else return true;
        }

        private bool InputValid()
        {
            bool valid = true;

            if (Alert || Sign.Equals('='))
                ClearAll();

            if (textBox1.Text.Length == 15)
            {
                MessageBox.Show("Больше вводить нельзя", "Внимание", MessageBoxButtons.OK);
                valid = false;
            }
            else if (textBox1.Text.Equals("0"))
                textBox1.Text = "";

            return valid;
        }

        private double OperationCalculate(double Number1,char Sign)
        {
            Number2 = float.Parse(textBox1.Text);

            switch (Sign)
            {
                case '+':
                    return Number1 + Number2;

                case '-':
                    return Number1 - Number2;

                case '*':
                    return Number1 * Number2;

                case '/':
                    if (Number2 != 0)
                        return Number1 / Number2;
                    else
                    {
                        MessageBox.Show("Делить на 0 нельзя", "Ошибка", MessageBoxButtons.OK);
                        ClearAll();
                        Alert = true;
                        return 0;
                    }

                case '^':
                    if (Number1 >= 0)
                        return Math.Pow(Number1, Number2);
                    else
                        if ((1 / Number2) % 2 == 1)
                        return -Math.Pow(-Number1, Number2);
                    else
                    {
                        MessageBox.Show("Не Действительное число", "Ошибка", MessageBoxButtons.OK);
                        ClearAll();
                        Alert = true;

                        return 0;
                    }

                default:
                    return Number2;
            }
        }        

        private void EquasionTransfer(char sign)
        {
            if (!maskedTextBox1.Text.EndsWith(" "))
                Equasion = maskedTextBox1.Text;

            switch (sign)
            {
                case '+':
                    maskedTextBox1.Text = Equasion + " + ";
                    break;
                
                case '-':
                    maskedTextBox1.Text = Equasion + " - ";
                    break;
                
                case '*':
                    maskedTextBox1.Text = "( " + Equasion + " ) * ";
                    break;
                
                case '/':
                    maskedTextBox1.Text = "( " + Equasion + " ) / ";
                    break;
                
                case '^':
                    maskedTextBox1.Text = "( " + Equasion + " ) ^ ";
                    break;
                
                default:
                    break;
            }
        }

        private void NumberTransfer()
        {
            if (maskedTextBox1.Text.EndsWith(" "))
                Equasion = maskedTextBox1.Text;
                   
            maskedTextBox1.Text = Equasion + textBox1.Text;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (InputValid())
                textBox1.Text += "0";

            NumberTransfer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (InputValid())
                textBox1.Text += "1";

            NumberTransfer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (InputValid())
                textBox1.Text += "2";

            NumberTransfer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (InputValid())
                textBox1.Text += "3";

            NumberTransfer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (InputValid())
                textBox1.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (InputValid())
                textBox1.Text += "5";

            NumberTransfer();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (InputValid())
                textBox1.Text += "6";

            NumberTransfer();
        }

        private void button7_Click(object sender, EventArgs e)
        { 
            if (InputValid())
                textBox1.Text += "7";

            NumberTransfer();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (InputValid())
                textBox1.Text += "8";

            NumberTransfer();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (InputValid())
                textBox1.Text += "9";

            NumberTransfer();
        }

        private void buttonNegPos_Click(object sender, EventArgs e)
        {
            NumberTransfer();

            if (textBox1.Text.Contains("-"))

                textBox1.Text = textBox1.Text.Remove(0, 1);
            else
                textBox1.Text = "-" + textBox1.Text;

            if (textBox1.Text.Equals("-0"))
                textBox1.Text = "0";

            NumberTransfer();
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            NumberTransfer();

            if (textBox1.Text.Equals("")) 
                textBox1.Text = "0,";

            if (textBox1.Text.Equals("0,"))
                textBox1.Text = "";

            if (!textBox1.Text.Contains(","))
                textBox1.Text = textBox1.Text + ",";

            NumberTransfer();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            EquasionTransfer('+');

            if (NotEmptyCheck())
                Number1 = OperationCalculate(Number1, Sign);
            textBox1.Text = "";
            Sign = '+';
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            EquasionTransfer('-');


            if (NotEmptyCheck())
                Number1 = OperationCalculate(Number1, Sign);
            textBox1.Text = "";
            Sign = '-';
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            EquasionTransfer('*');

            if (NotEmptyCheck())
                Number1 = OperationCalculate(Number1, Sign);
            textBox1.Text = "";
            Sign = '*';
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            EquasionTransfer('/');

            if (NotEmptyCheck())
                Number1 = OperationCalculate(Number1, Sign);
            textBox1.Text = "";
            Sign = '/';
        }

        private void buttonPower_Click(object sender, EventArgs e)
        {
            EquasionTransfer('^');

            if (NotEmptyCheck())
                Number1 = OperationCalculate(Number1, Sign);
            textBox1.Text = "";
            Sign = '^';
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (NotEmptyCheck())
                Number1 = OperationCalculate(Number1, Sign);
            
            textBox1.Text = Number1.ToString();
            Equasion = "";
            maskedTextBox1.Text = Number1.ToString();
            Sign = '=';
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (NotEmptyCheck())
                textBox1.Text = textBox1.Text.Remove((textBox1.Text.Length - 1), 1);

            if (textBox1.Text.Equals("0,"))
                textBox1.Text = "";

            maskedTextBox1.Text = Equasion + textBox1.Text;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
