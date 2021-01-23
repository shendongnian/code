    public User Get([FromUri] User cst)
    {
        if (cst == null)
            throw new HttpResponseException(HttpStatusCode.NotFound);
        using (var DB2Conn = new OdbcConnection(constr))
        using (var com = new OdbcCommand("SELECT name FROM [TABLE] WHERE customerNumber = ? FETCH FIRST 1 ROWS ONLY", DB2Conn))
        {
            com.Parameters.AddWithValue("@var", cst.customerNumber);
            DB2Conn.Open();
            cst.name = (string)com.ExecuteScalar();
        }
        return cst;
    }
