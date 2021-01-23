    string tableName = "FormField";
    using (SqlCommand sqlCmd2 = new SqlCommand())
        {
            sqlCmd2.Connection = sqlConn2;
            sqlCmd2.CommandType = System.Data.CommandType.Text;
            sqlCmd2.CommandText = string.Format("SELECT DisplayName AS MyColumn FROM {0} WHERE EventId = 1 AND Visible = 1", tableName );
            
            sqlCmd2.ExecuteNonQuery();
        }
