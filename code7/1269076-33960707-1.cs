    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        public void info(string str)
        {
            this.richTextBox1.AppendText(str);
        }
    }
