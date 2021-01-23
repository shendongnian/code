    var query = tags.AsQueryable();
    if(ID != "")
        query = query.Where(w => w.ID == ID);
    // add second filter
    if( part != "")
        query = query.Where(w => w.PartNumber == part);
    return query.ToList();
