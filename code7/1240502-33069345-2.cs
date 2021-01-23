    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Global.f1 = this;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Global.f2.ShowDialog();
        }
    }
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Global.f1.Show();
        }
    }
