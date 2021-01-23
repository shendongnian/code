    using (SqlConnection sc = new SqlConnection(sConn))
    {
       sc.Open();
       using (SqlDataAdapter adapter = new SqlDataAdapter())
       {
           adapter.SelectCommand = new SqlCommand("SELECT * FROM Student", sc);
           var dataset = new DataSet();
           adapter.Fill(dataset);
           var dt = dataset.Tables[0];
           var dv = dt.DefaultView;
           dv.RowFilter = String.Concat("[Forename] LIKE '%", SearchFor, "%'");
           grdData.ItemsSource = dv;
       }
    }
