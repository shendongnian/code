    public class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            m_lines = System.IO.File.ReadAllLines(path).GetEnumerator();
        }
        private IEnumerator<string> m_lines;
        public void Button_Click(object sender, EventArgs e)
        {
            if (m_lines.MoveNext())
                TextBox1.Text = m_lines.Current;
            else
                MessageBox.Show("End of file!");
        }
    }
