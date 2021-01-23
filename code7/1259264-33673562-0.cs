    using (SqlConnection sqlConn2 = new sqlConnection(ConfigurationManager.ConnectionStrings["ConnectionNameHere"].ConnectionString))
    {
        sqlConn2.Open();
        
        using (SqlCommand sqlCmd2 = new SqlCommand())
        {
            sqlCmd2.Connection = sqlConn2;
            sqlCmd2.CommandType = System.Data.CommandType.Text;
            sqlCmd2.CommandText = string.Format("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS mWHERE table_name = 'registrants');
            var dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);            
            sqlConn2.Close();
            return dataTable;
        }
    }
