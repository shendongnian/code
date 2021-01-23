    var Query = Db.TblUsers.AsQueryable();
    
    switch (Order)
    {
        case "Name": Query = ascending ? 
                         Query.OrderBy(q=>q.Name) : 
                         Query.OrderByDescending(q=>q.Name);
            break;
        case "DOB": Query = ascending ? 
                         Query.OrderBy(q=>q.DOB) : 
                         Query.OrderByDescending(q=>q.DOB);
            break;
        // ... and more cases
    }
    
    var Result = Query.ToList();
