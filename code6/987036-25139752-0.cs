    private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowData();
        }
        private void ShowData()
        {
            SqlConnection con = new SqlConnection(String.Format(@"Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", SQLSERVER_ID, SQLDatabaseName, SQLServerLoginName, SQLServerPassword));
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT * FROM Bags", con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(dt);
            listView1.DataContext = dt.DefaultView;
        }
