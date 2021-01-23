    using (var dbSqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString1"]))
        { 
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(
                queryString, dbSqlConnection );
            adapter.Fill(ds);
        }
