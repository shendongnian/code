    int deleted, updated;
    string connection = ConfigurationManager.ConnectionStrings["PaydayLunchConnectionString1"].ConnectionString;
    using (var conn = new SqlConnection(connection))
    {
        conn.Open();
        string delSql = "DELETE FROM Users WHERE Name = @Name";
        using (var cmd = new SqlCommand(delSql, conn))
        {
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = txtRemoveUser.Text;
            deleted = cmd.ExecuteNonQuery();
        }
        
        string updSql = @"UPDATE Admin_TaskList 
                          SET Status = 'Complete' 
                          WHERE Description = 'Remove User' 
                          AND Name = @Name";
        using (var cmd = new SqlCommand(updSql, conn))
        {
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = txtRemoveUser.Text;
            updated = cmd.ExecuteNonQuery();
        }
    }
