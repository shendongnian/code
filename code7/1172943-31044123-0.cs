    public partial class Form2 : Form
    {
        private bool ForceClose = true;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ForceClose)
                Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GlolbalUtil.LogIn_Status = "false";
            ForceClose = false;
            this.Close();
        }
    }
