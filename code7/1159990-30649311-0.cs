    private String connectionString = "someOleDbConnectionString";
    public String UpdateObject(Object obj)
    {
        OleDbConnection connection = GetMyOleDbConnection(); //returns new OleDbConnection with proper connection string
        String updateSql = "UPDATE [Wpisy] SET [wpis]=@wpis, [id_kat]=@id_kat, [tytul]=@tytul WHERE [ID]=@id_wpis";
        OleDbCommand command = new OleDbCommand(updateSql, connection);
        command.CommandType = System.Data.CommandType.Text; //this can be changed if you have stored procedures in your db.
        //you may have to define the OleDbType of the parameter being defined
        command.Parameters.Add(new OleDbParameter("@wpis", OleDbType.VarChar, obj.tresc_wpisu));
        command.Parameters.Add(new OleDbParameter("@id_kat", OleDbType.VarChar, obj.lista_kategorii));
        command.Parameters.Add(new OleDbParameter("@tytul", OleDbType.VarChar, obj.tytul_wpisu));
        command.Parameters.Add(new OleDbParameter("@id_wpis", OleDbType.Integer, obj.id.ToString())); 
        return Execute(connection, command);
    }
    private OleDbConnection GetMyOleDbConnection()
    {
        return new OleDbConnection(connectionString);
    }
    private String Execute(OleDbConnection connection, OleDbCommand command)
    {
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
            //I also know with Access databases, 
            //sometimes you have to close the table if it is open in MS Access
            connection.Close();
            return "SUCCESS";
        }
        catch (Exception ex)
        {
            connection.Close(); //important or you will have left open connections
            Response.Clear();
            Response.Write(ex.Message);
            Response.End();
            return ex.Message;
        }
    }
