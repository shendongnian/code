    using (SqlConnection connUser = new SqlConnection(conn))
    {
        string upd = "UPDATE ItemTransaction SET ItemStatus = @status WHERE ID = @id";
        connUser.Open();
        SqlCommand commandSQL = connUser.CreateCommand();
        for (int i = 0; i < gvModal.Rows.Count; i++)
        {
            // Get values here using your code
            commandSQL.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
            commandSQL.Parameters.Add("@id", SqlDbType.VarChar).Value = ItemID.Text;
            commandSQL.ExecuteNonQuery();
            commandSQL.Parameters.Clear();                   
        }
    }
