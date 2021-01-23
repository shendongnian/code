    public partial class Overview : Form
    {
        public Overview()
        {
            InitializeComponent();
        }
    
        private ListViewItem lvi;
        public ListViewItem SelectedItem
        {
            get
            {
                return lvi;
            }
            set
            {
                lvi = value;
            }
        }
    
        private void listView1Overview_DoubleClick(object sender, EventArgs e)
        {
            SelectedItem = listView1Overview.SelectedItems[0];
            Close();
        }
    }
