    using (SqlCommand cmd1 = new SqlCommand("UPDATE mondayTable SET [" + ClassTime +"] = @newValue WHERE [" + ClassTime + "] = @oldValue", SQLCONN)) //or WHERE newGroup?
    {
        cmd1.Parameters.AddWithValue("@newValue", newTeacherClassRoom);
        cmd1.Parameters.AddWithValue("@oldValue", teacherandclassroom);
        cmd1.ExecuteNonQuery();
        Console.WriteLine("Database Updated...");
    }
