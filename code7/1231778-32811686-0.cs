    public partial class Form2 : Form
    {
        //this is a property
        public string TextBox1
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public Form2()
        {
            InitializeComponent();
        }
    }
