    public static bool methodName(string query, params KeyValuePair<string, string>[] parameters)
    {
        bool success = false;
        DBConnection db = new DBConnection(); //Oracle connection class
        db.Connect(); //Connect to the database
    
        if (db.GetConnectionState())  //checks the connection
        {
            db.SetSql(query);
            foreach(var param in parameters) db.addParameter(param.Key, param.Value);
    
            if (db.ExecuteTransactions())  //attempts to insert, delete, update, whatever
                success = true;
            else
                success = false;
        }
        else
            success = false;
    
        db.Dispose();
    
        return success;    
    }
