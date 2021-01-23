    var conn = new SqlConnection("{connectionString}"));
    var context =  new DbContext(conn, contextOwnsConnection: false);
    ...
    if(conn.State == ConnectionState.Closed) {
        conn.Open(); 
    }
    context.SaveChanges(); 
    
    ...
    context.Dispose();
    conn.Dispose();
