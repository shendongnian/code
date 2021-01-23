    public partial class MainWindow : Window
    {
        public List<Item> Items
        {
            get
            {
                return new List<Item>()
                {
                    new Item(),
                    new Item(),
                    new Item(),
                    new Item(),
                };
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void TreeViewItem_CancelRequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            e.Handled = true;
        }
    }
