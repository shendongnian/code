        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                OracleCommand cmdd = new OracleCommand("select * from employees", conn);
                conn.Open();
                cmdd.ExecuteNonQuery();
                OracleDataReader dr = cmdd.ExecuteReader();
                OracleDataAdapter da = new OracleDataAdapter(cmdd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                listboxReport.ItemsSource = dt.AsDataView();
                listboxReport.DisplayMemberPath = dt.Columns[1].ToString();
            }
        }
