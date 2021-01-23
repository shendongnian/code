    class A1 {public int Id {get; set;}}   
    class A2 {public string Name {get; set;}}  
    ...
     
    var templist = db.Database.SqlQuery<A1>(sql_dinamic).ToList(); 
    or 
    var templist = db.Database.SqlQuery<A2>(sql_dinamic).ToList(); 
