    using (var connect = sqlcon.getConnection())
    {
        string updateRecordCmd = String.Format( "UPDATE pending SET status='1' WHERE ID={0}",row.Cells[0].Value.toString());  
        using (SqlCommand cmd = new SqlCommand(updateRecordCmd))
        {
            cmd.Connection = connect;
            connect.Open();
            //cmd.ExecuteNonQuery();
            //connect.Close();
    
        }
    }
