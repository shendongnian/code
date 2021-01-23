    public partial class addtoLibraryDialog : Form
    {
        ListView objLV;
        public addtoLibraryDialog()
        {
            InitializeComponent();
        }
        public addtoLibraryDialog(ref ListView lv)
        {
            objLV = lv;
            InitializeComponent();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            ListViewItem list = new ListViewItem("name");
            list.SubItems.Add("path");
            objLV.Items.Add(list);
        }
    }
