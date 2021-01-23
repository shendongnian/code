    var row = from rw in dt.AsEnumerable()
                   select new {    id = rw.Field<int>("rowID"),
                                 user = rw.Field<string>("username")
                                 pass = rw.Field<string>("password"),
                               access = rw.Field<string>("access"),
                                logID = rw.Field<string>("logID")};
     /* ex.: this only work on LinQ to SQL where I use a "foreach" to 
        gather up results of the column retrieved based on the 
        query statement executed.
      if(row.Any())
       { 
         foreach(var r in row) 
         {
            id = r.id;
            user = r.user;
            pass = r.pass;
            access = r.access;
            logID = r.logID  
         }
       }
    */
          
