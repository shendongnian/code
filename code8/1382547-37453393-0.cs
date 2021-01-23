    /****************** pseudo code ******************/
    
        SomeClass obj = new SomeClass();
        obj.SomeProperty = someValue;
        // INSERT TO database with Dapper.
        
        // The generated ID is autmotaically get from the database using
        // SELECT CAST(SCOPE_IDENTITY() AS INT);
        // so this next line prints the ID generated in the database.
        Console.WriteLine(obj.ID)
;
