    public string selectField(string tblName, string colTarget, string colRef, string refValue)
    {    
        string query = string.Format(
            "SELECT {0} FROM {1} WHERE {2} = @refValue;",
            colTarget,
            tblName,
            colRef);
    
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.Add("@refValue", SqlDbType.VarChar).Value = refValue;  
    
        //open connection and execute query
        //close connection
        //return field value    
    }
