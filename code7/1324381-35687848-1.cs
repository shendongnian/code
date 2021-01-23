    public int DeleteById(int Id)
    {
            string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"datubaze.accdb\"";
            OleDbConnection con = new OleDbConnection(ConnectionString);
            OleDbCommand cmd = new OleDbCommand("DELETE FROM PERSONA WHERE ID = @ID", con);
            cmd.Parameters.Add(new OleDbParameter("ID", Id));
            return cmd.ExecuteNonQuery();
    }
