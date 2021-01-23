    string query = "INSERT INTO client" +
                 " (name, surname)" +
                 " VALUES (@Name, @Surname);" +
                 " SELECT SCOPE_IDENTITY();";
    using (var dbconn = new SqlConnection("your connection string here") )
    using (var dbcm = new SqlCommand(query, dbconn) )
    {
        dbcm.Parameters.Add("@Name", SqlDbType.VarChar, 20).Value = "name value";
        dbcm.Parameters.Add("@Surname", SqlDbType.VarChar, 40).Value = "surname value";
        dbconn.Open();
        var insertedID = (int)dbcm .ExecuteScalar();
    }
