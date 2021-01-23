    MyContext db = ...   // class derived from DbContext
    ...
    if (db.HasTableNamed("MyOptionalTable"))
    {
        // the table exists in the database
    }
    else
    {
        // the table DOES NOT exist in the database
    }
