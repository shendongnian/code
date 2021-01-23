    static DataSet TestMethod()
    {
        DataSet ds = new DataSet();
    
        using(var con = new SqlConnection("Connection-String"))
        using(var da = new SqlDataAdapter("SELECT t.* FROM TableName t ORDER BY t.Column", con))
            da.Fill(ds);
    
        return ds;
    }
