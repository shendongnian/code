    public partial class MainWindow
    {
        private DataTable _datatable1;
        public MainWindow()
        {
            InitializeComponent();
            _datatable1 = new DataTable();
            _datatable1.Columns.Add(new DataColumn("id", typeof(int)));
            _datatable1.Columns.Add(new DataColumn("name", typeof(string)));
            _datatable1.Columns.Add(new DataColumn("st", typeof(string)));
            _datatable1.Rows.Add(1, "row1", "st1");
            _datatable1.Rows.Add(2, "row2", "st2");
            _datatable1.Rows.Add(3, "row3", "st3");
            _datatable1.Rows.Add(4, "row4", "st4");
            _datatable1.Rows.Add(5, "row5", "st5");
            _datatable1.Rows.Add(6, "row6", "st6");
            _datatable1.DefaultView.Sort = "st DESC";
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
        private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {
            _datatable1.Rows[3][0]= 6;
            _datatable1.Rows[3][1] = "row6";
            _datatable1.Rows[3][2] = "st6";
            LsVTest.ItemsSource = _datatable1.DefaultView;
        }
    }
