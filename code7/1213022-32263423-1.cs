    using (SqlConnection conn = new SqlConnection(ConnString))
    {
        using (SqlCommand comm = new SqlCommand())
        {
            comm.Connection = conn;
            conn.Open();
            for(int i=0; i< dataGridView1.Rows.Count;i++)
            {
                StrQuery= @"INSERT INTO tableName VALUES (" 
                    + pendingdataGridView.Rows[i].Cells["ColumnName"].Value +", " 
                    + pendingdataGridView.Rows[i].Cells["ColumnName"].Value +");";
                comm.CommandText = StrQuery;
                comm.ExecuteNonQuery();
            }
        }
    }
