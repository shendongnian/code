    using (var dbSqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString1"]))
        { 
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(
                queryString, dbSqlConnection );
            adapter.Fill(dataset);
            return dataset;
        }
