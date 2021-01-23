    public partial class MainWindow
    {
        private DataTable _datatable1;
        public MainWindow()
        {
            InitializeComponent();
            _datatable1 = new DataTable();
            _datatable1.Columns.Add(new DataColumn("id", typeof(int)));
            _datatable1.Columns.Add(new DataColumn("name", typeof(string)));
            
            _datatable1.Rows.Add(1, "row1");
            _datatable1.Rows.Add(2, "row2");
            _datatable1.Rows.Add(3, "row3");
            _datatable1.DefaultView.Sort = "id DESC";
            LsVTest.ItemsSource = _datatable1.DefaultView;
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var query = "id=2" ;
            var rows = _datatable1.Select(query);
            if (rows.Length <= 0) return;
            var row = rows[0];
            var index = _datatable1.Rows.IndexOf(row);
            LsVTest.SelectedIndex = index;
        }
    }
