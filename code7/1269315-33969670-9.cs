    public partial class Form2 : Form
    {
        public string MyNewText;
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MyNewText = textBox1.Text;
            Close();
        }
    }
