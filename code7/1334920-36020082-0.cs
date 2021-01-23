    using(var connection = new OleDbConnection(conString))
    using(var cmd = connection.CreateCommand())
    {
        cmd.CommandText = "insert into myTable(colx,coly,colz) values(?, ?, ?)";
        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = dt.Rows[i]["a"].ToString().Trim();
        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = dt.Rows[i]["b"].ToString().Trim();
        cmd.Parameters.Add("?", OleDbType.Date).Value = (DateTime)dt.Rows[i]["c"];
    
        connection.Open();
        cmd.ExecuteNonQuery();  
    }
