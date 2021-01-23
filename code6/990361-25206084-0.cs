    if (!string.IsNullOrEmpty(query.name))
    {
        //do something
    }
    if (Data == null)
    {
        Data = db.data; //this will always be null if the query object was null
    }
