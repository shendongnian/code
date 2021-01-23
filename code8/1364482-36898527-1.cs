    public partial class TabControlWithAdd : UserControl
    {
        public TabControlWithAdd()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add("Tab " + (tabControl1.TabPages.Count + 1));
        }
    }
