    int deleted, updated;
    string connection = ConfigurationManager.ConnectionStrings["PaydayLunchConnectionString1"].ConnectionString;
    using (var conn = new SqlConnection(connection))
    {
        conn.Open();
        using (var cmd = new SqlCommand("DELETE FROM Users WHERE Name = @Name", conn))
        {
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = txtRemoveUser.Text;
            deleted = cmd.ExecuteNonQuery();
        }
        using (var cmd = new SqlCommand("UPDATE FROM Admin_TaskList SET Status = 'Complete' WHERE Description = 'Remove User' AND Name = @Name"))
        {
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = txtRemoveUser.Text;
            updated = cmd.ExecuteNonQuery();
        }
    }
