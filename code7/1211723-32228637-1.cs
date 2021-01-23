	public MainWindow()
	{
		InitializeComponent();
		_datatable1 = new DataTable();
		_datatable1.Columns.Add(new DataColumn("id", typeof(int)));
		_datatable1.Columns.Add(new DataColumn("name", typeof(string)));
		_datatable1.Columns.Add(new DataColumn("st", typeof(int)));
		_datatable1.DefaultView.Sort = "st DESC";
		LsVTest.ItemsSource = _datatable1.DefaultView;
		_datatable1.Rows.Add(1, "row1", 6);
		_datatable1.Rows.Add(2, "row2", 2);
		_datatable1.Rows.Add(3, "row3", 8);
		_datatable1.Rows.Add(4, "row4", 4);
		_datatable1.Rows.Add(5, "row5", 9);
		_datatable1.Rows.Add(6, "row6", 6);
		_datatable1 = _datatable1.DefaultView.ToTable();
		_datatable1.DefaultView.Sort = "st DESC";
		LsVTest.ItemsSource = _datatable1.DefaultView;
	}
	private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
	{
		var query = "id=3";
		var rows = _datatable1.Select(query);
		if (rows.Length <= 0) return;
		var row = rows[0];
		var index = _datatable1.Rows.IndexOf(row);
		LsVTest.SelectedIndex = index;
	}
	private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
	{
		DataRow[] Rows = _datatable1.Select("id=" + 3);
		Rows[0]["st"] = 10;
		_datatable1 = _datatable1.DefaultView.ToTable();
		_datatable1.DefaultView.Sort = "st DESC";
		LsVTest.ItemsSource = _datatable1.DefaultView;
	}
