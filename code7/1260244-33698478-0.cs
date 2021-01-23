    [WebMethod]
    public static object getData(string id, string type, string[] filters)
    {    
        //do some validation of inputs
        //execute a stored procedure and process with LINQ
    
        var _lock = new object();
    
        lock(_lock)
        {
            return new { Result = "OK", Records = results, TotalRecordCount = unpagedTotal };
        }
    }
