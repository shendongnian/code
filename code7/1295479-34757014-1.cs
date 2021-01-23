    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.OK;
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string FirstName { get { return textBox1.Text; } }
        public string LastName { get { return textBox2.Text; } }
    }
