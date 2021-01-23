    public partial class Form2 : Form
    {
        TextBox s;
        public Form2(TextBox s)
        {
            InitializeComponent();
            this.s = s;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String str = textBox1.Text;
            s.Text = str;
        }
    }
