     using (conn = new SqlConnection(cs)) { 
        SqlCommand deleteCommand = new SqlCommand("delete from Users where UserID = @id", conn);
        deleteCommand.Parameters.AddWithValue("@id", id);
        conn.Open();
        int rowsDeleted = deleteCommand.ExecuteNonQuery();
        if (rowsDeleted != 1) {
            // something unexpected happened
        }
    }
