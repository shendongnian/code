    public partial class Form1 : Form
    {
        Form2 fm2;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            fm2 = new Form2();
            fm2.Show();
            fm2.button1.Click += new EventHandler(fm2button1_Click);
        }
        private void fm2button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = fm2.textBox1.Text;
        }
        
    }
