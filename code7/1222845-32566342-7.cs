    public partial class TableView: Window
    {
     
        public TableView(int rows, int colums)
        {
            InitializeComponent();
            DataContext = new TableViewModel();
            //do whatever needed with rows and columns parameters. 
            //You will probably need then in TableViewModel
        }
        TableViewModel ViewModel
        {
            get { return (TableViewModel )DataContext; }
        }
    }
