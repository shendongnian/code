    public partial class Form1 : Form
        {
            private int a, b, c;
            private void button1_Click(object sender, EventArgs e)
            {
                if (radioButton1.Checked) a = 5; else a = 0;
                if (radioButton2.Checked) b = 5; else b = 0;
                if (radioButton3.Checked) c = 5; else c = 0;
            }
        }        
