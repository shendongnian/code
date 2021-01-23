    public partial class Form2 : Form
    {
        private readonly Form1 _parent;
        public Form2(Form1 parent)
        {
            InitializeComponent();
            _parent = parent;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _parent.label1.Text = textBox1.Text;
            Close();
        }
    }
