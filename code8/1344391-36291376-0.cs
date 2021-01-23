    public partial class SearchWindow : Form
    {
        public String SearchKey{
           get{return searchKey_textbox.Text}
        }
        public SearchWindow()
        {
            InitializeComponent();
        }
        private void SearchButtonW_Click(object sender, EventArgs e)
        {
        }
        public void searchBtn_attachClickHandler(EventHandler eh){
             searchBtn.Click += eh;
        }
    }
