    string sql = @"UPDATE MyTable SET HS=@HS WHERE Md = @MD AND HT=@HT";
    
    using (OleDbConnection dbcon = new OleDbConnection(AceConnStr))
    { 
        // other code
        using (OleDbCommand cmd = new OleDbCommand(sql, dbcon))
        { 
            // add in the same order as in SQL
            // I have no idea that these are
            cmd.Parameters.Add("@HS", OleDbType.VarChar).Value = Hs;
            cmd.Parameters.Add("@MD", OleDbType.Date).Value = Md;
            cmd.Parameters.Add("@HT", OleDbType.Integer).Value = Ht;
            int rows = cmd.ExecuteNonQuery();
            
        }   // closes and disposes of connection and command objects
    }
