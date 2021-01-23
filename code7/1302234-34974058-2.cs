    namespace WindowsFormsApplication4
    {
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
    }
