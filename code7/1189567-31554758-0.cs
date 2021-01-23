    private void DataGrid_Loaded(object sender, RoutedEventArgs e)
    {
        string connstr = ConfigurationManager.ConnectionStrings["WpfApplication14.Properties.Settings.NorthwindConnectionString"].ToString();
        SqlConnection conn = new SqlConnection(connstr);
        CustomersTableAdapter adapter = new CustomersTableAdapter();
        NorthwindDataSet.CustomersDataTable table = new NorthwindDataSet.CustomersDataTable();
        adapter.Fill(table);
        dataGrid1.ItemsSource = table.DefaultView;
        table.RowChanged += table_RowChanged;
    }
    void table_RowChanged(object sender, System.Data.DataRowChangeEventArgs e)
    {
        using (CustomersTableAdapter adapter = new CustomersTableAdapter())
        {
            adapter.Update(sender as NorthwindDataSet.CustomersDataTable);
        }
    }
