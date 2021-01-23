    using(var conn = new SqlConneciton(conStr))
    using(var com = conn.CreateCommand())
    {
       // Define your CommandText
       // Add your parameter values with Add method.
    
       using(var da = new SqlDataAdapter(com))
       {
           // Do your stuff
       }
    }
