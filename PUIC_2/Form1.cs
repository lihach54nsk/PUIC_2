using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PUIC_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool start;
        double num, inputX, deltaX;
        int dec;

        LinkedList<double> steps = new LinkedList<double>();

        private void startButton_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            checkBox0.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;

            start = true;
            num = 0;
            dec = 0;
            inputX = double.Parse(inputTextBox.Text);
            deltaX = double.Parse(deltaTextBox.Text);
            steps.Clear();

            while (start)
            {
                second();
                fourth();
            }

            resultTextBox.Text = dec.ToString();
            var binary = Convert.ToString(dec, 2);
            binaryTextBox.Text = binary;

            int count = 0;
            foreach (var check in binary.Reverse())
            {
                switch (count)
                {
                    case 0: if (check == '1') checkBox0.Checked = true; break;
                    case 1: if (check == '1') checkBox1.Checked = true; break;
                    case 2: if (check == '1') checkBox2.Checked = true; break;
                    case 3: if (check == '1') checkBox3.Checked = true; break;
                    case 4: if (check == '1') checkBox4.Checked = true; break;
                    case 5: if (check == '1') checkBox5.Checked = true; break;
                    case 6: if (check == '1') checkBox6.Checked = true; break;
                    case 7: if (check == '1') checkBox7.Checked = true; break;
                }
                count++;
            }

            foreach (var a in steps)
            {
                chart1.Series[0].Points.AddY(a);
                chart1.Series[1].Points.AddY(inputX);
            }
        }

        void second()
        {
            if (num >= inputX)
            {
                start = false;
            }
        }

        void fourth()
        {
            if (start)
            {
                dec++;
                num = dec * deltaX;
                steps.AddLast(num);
            }
            else return;
        }
    }
}