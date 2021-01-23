    using (SqlTransaction tx = connection.BeginTransaction())
    {
        string sql = "SELECT id FROM Courses WHERE column = @Name";
        SqlCommand cmd = new SqlCommand(sql, connection);
        cmd.Parameters.Add("@Name", SqlDbType.VarChar);
        cmd.Parameters["@Name"].Value = ...;
        Object id = cmd.ExecuteScalar();
        if (id == null)
        {
            sql = "INSERT INTO Courses(Name) VALUES(@Name)";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar);
            cmd.Parameters["@Name"].Value = ...;
            cmd.ExecuteNonQuery();
            id = cmd.ExecuteScalar("SELECT last_insert_rowid()");
        }
        tx.Commit();
    }
