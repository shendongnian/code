    public class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            m_Reader = new StreamReader(path);
        }
        private readonly StreamReader m_Reader;
        protected override Dispose(bool disposing)
        {
            if(m_Reader != null)
            {
                m_Reader.Dispose();
                m_Reader = null;
            }
            base.Dispose(disposing);
        }
        public void Button_Click(object sender, EventArgs e)
        {
            TextBox1.Text = m_Reader.ReadLine() ?? "[End of File]";
        }
    }
