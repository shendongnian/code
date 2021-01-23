    public class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            m_lines = System.IO.File.ReadLines(path).GetEnumerator();
            // alternatively, m_lines = System.IO.File.ReadAllLines(path).GetEnumerator();
            // this would read it all at once, which would have the advantage of not locking up the file, but would take longer to load and would be harder on memory.
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
