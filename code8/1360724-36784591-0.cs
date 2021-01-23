    public partial class Form1 : Form
    {
        Form2 f2;
        Form3 f3;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            f2 = new Form2();
            f2.FormClosing += F2_FormClosing;
            this.Hide();
            f2.Show();
        }
        private void F2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (((Form2)sender).DialogResult == DialogResult.OK)
            {
                f3 = new Form3();
                f3.FormClosing += F3_FormClosing;
                f3.Show();
            }
            else
            {
                this.Visible = true;
            }
        }
        private void F3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (((Form3)sender).DialogResult == DialogResult.OK)
            {
                f2 = new Form2();
                f2.FormClosing += F2_FormClosing;
                f2.Show();
            }
            else
            {
                this.Visible = true;
            }
        }
    }
