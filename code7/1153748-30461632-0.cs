    public partial class Form1 : Form
    {
        Timer timer = null;
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 250;
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            int num = this.txtPassword.Text.Count();
            if (num > 0)
            {
                StringBuilder s = new StringBuilder(this.txtPassword.Text);
                s[num - 1] = '*';
                this.Invoke(new Action(() =>
                {
                    this.txtPassword.Text = s.ToString();
                    this.txtPassword.SelectionStart = this.txtPassword.Text.Count();
                }));
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int num = this.txtPassword.Text.Count();
            if (num > 1)
            {
                StringBuilder s = new StringBuilder(this.txtPassword.Text);
                s[num - 2] = '*';
                this.txtPassword.Text = s.ToString();
                this.txtPassword.SelectionStart = num;
                timer.Enabled = true;
            }
        }
    }
