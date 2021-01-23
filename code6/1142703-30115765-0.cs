    public partial class Form1 : Form
    {
        Form2 form2;
        public Form1()
        {
            form2 = new Form2();
            form2.Show();
            InitializeComponent();
        }
       
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (form2.AskBeforeClosing)
            { 
                e.Cancel = MessageBox.Show("Are you sure?","",MessageBoxButtons.OKCancel)==System.Windows.Forms.DialogResult.Cancel;
            }
        }
    }
    public partial class Form2 : Form
    {
        public bool AskBeforeClosing
        {
            get {
                return textBox1.Text != "";
            }
        }
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
        }
    }
