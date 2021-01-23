    var query = db.People.Select(t=> new {Name = t.FirstName + " " + t.LastName});    
    if(orderByLastName)
    {
         query  = query.OrderBy(t=>t.LastName)
    }
    else
    {
         query  = query.OrderBy(t=>t.FirstName)
    }
