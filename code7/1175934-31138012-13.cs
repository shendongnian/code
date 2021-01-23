    public partial class MainWindow : Window
    {
    ....
        public ErrorContainer Error { get; set; }
            public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            
            // initialize ErrorContainer
            Error = new ErrorContainer();
            // some dummy test data (you're probably getting your data from DB instead)
            DataSet ds = new DataSet("MyDataSet");
            DataTable dt = new DataTable("MyDataTable");
            DataColumn propertyName = new DataColumn("Property");
            DataColumn propertyValue = new DataColumn("Value");
            DataColumn propertyDate = new DataColumn("Date", typeof(DateTime));
            dt.Columns.Add(propertyName);
            dt.Columns.Add(propertyValue);
            dt.Columns.Add(propertyDate);
            dt.Rows.Add("Name1", 1, DateTime.Now);
            dt.Rows.Add("Name2", 2, DateTime.Now);
            dt.Rows.Add("Name3", 3, DateTime.Now);
            ds.Tables.Add(dt);
            // bind DataGrid.ItemsSource (do NOT set this again in xaml)
            var srcBinding = new Binding();
            srcBinding.Source = ds.Tables[0].DefaultView;
            myDataGrid.SetBinding(DataGrid.ItemsSourceProperty, srcBinding);
        }
    }
