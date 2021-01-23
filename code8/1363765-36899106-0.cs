    switch (sortOrder)
    {
         case "total":
            records = db.Records.Where(t => t.Active == true).AsQueryable().OrderBy(u => u.Total));
            break;
        case "rating_desc":
            records = db.Records.Where(t => t.Active == true).AsQueryable.OrderByDescending(u => u.Total).;
            break;
        default:
            records = db.Records.Where(t => t.Active == true).AsQueryable.OrderBy(u => u.Title).;
            break;
    }
