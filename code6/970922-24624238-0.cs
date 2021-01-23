    public partial class Form1 : Form
    {
        private bool closing;
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void TextBox1LeaveMethod()
        {
            textBox1.BackColor = Color.Red;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (!closing)
                TextBox1LeaveMethod();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing = true;
        }
    } 
