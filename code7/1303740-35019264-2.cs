    public User Get([FromUri] User cst)
    {
        if (cst == null)
            throw new HttpResponseException(HttpStatusCode.NotFound);
        using (var DB2Conn = new OdbcConnection(constr))
        using (var com = new OdbcCommand("SELECT * FROM [TABLE] WHERE customerNumber = ?", DB2Conn))
        {
            com.Parameters.AddWithValue("@var", cst.customerNumber);
            DB2Conn.Open();
            using (OdbcDataReader reader = com.ExecuteReader())
                while (reader.Read())
                {
                    cst.name = (string)reader["name"]
                    return cst;
                }
        }
        return cst;
    }
