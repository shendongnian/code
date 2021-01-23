    string sConn = @"Data Source=WOLFSQLDEV3;Initial Catalog=Ben;User ID=tester1;Password=david;";
    using (SqlConnection sc = new SqlConnection(sConn))
    {
       sc.Open();
       SqlDataAdapter adapter = new SqlDataAdapter();
       adapter.SelectCommand = new SqlCommand("SELECT * FROM Student", sc);
       var dataset = new DataSet();
       adapter.Fill(dataset);
       var dt = dataset.Tables[0];
       var dv = dt.DefaultView;
       dv.RowFilter = String.Concat("[Forename] LIKE '%", SearchFor, "%'");
       grdData.ItemsSource = dv;
    }
