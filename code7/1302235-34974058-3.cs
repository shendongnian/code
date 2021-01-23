    public partial class Form2 : Form
    {
        private bool m_bReallyClose = false;
    
        public Form2()
        {
            InitializeComponent();
        }
    
        private void Form2_Load(object sender, EventArgs e)
        {
    
        }
    
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!m_bReallyClose)
            {
                this.Visible = false;
    
                e.Cancel = true;
            }
        }
    
        public void ReallyClose()
        {
            m_bReallyClose = true;
    
            this.Close();
        }
    }
    
    public partial class Form1 : Form
    {
        Form2 decript_form = new Form2();
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            if (!decript_form.Visible)
                decript_form.Show();
    
            else
                MessageBox.Show("Form already open!");
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            decript_form.Dispose(); // or .ReallyClose();
            decript_form = new Form2();
        }
    }
