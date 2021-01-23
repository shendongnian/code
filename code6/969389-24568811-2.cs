    var query = db.People;    
    if(orderByLastName)
    {
         query  = query.OrderBy(t=>t.LastName)
    }
    else
    {
         query  = query.OrderBy(t=>t.FirstName)
    }
    query = query.Select(t=> new {Name = t.FirstName + " " + t.LastName});
