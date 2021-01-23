    string query = "Select * From TempDB.DBO.SysObjects Where Name='##' + @UserName";
    using (var conn = new SqlConnection(connection))
    {
        using (SqlCommand command = new SqlCommand(query, conn))
        {
    command.Parameters.Add(
    new SqlParameter("@UserName",SqlDbType.Varchar,50) {
        Value = userName.ToUpper()
    );
            conn.Open();
            command.ExecuteNonQuery();
        }
    }
