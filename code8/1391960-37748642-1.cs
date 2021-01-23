    var db = database.TableName.ToList()
    if(!String.IsNullOrWhiteSpace(s_SearchString)) // can also use string method String.IsNullOrEmpty.. your preference
    {
        return db.Where(x => x.Name.StartsWith(s_SearchString)).ToList(); // using lambda expression
    }
    else
    {
        return db;  // s_SearchString is Null or White Space so return all records
    }
    
