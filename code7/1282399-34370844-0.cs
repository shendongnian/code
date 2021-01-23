    var items = from pg in PhotoGroups
                join o in Opportunities
                    on pg.OpportunityId equals o.Id
                join p in Photos 
                    on new { p.CreatedTimestampUtc, p.DocumentType, p.OpportunityId } equals new { CreatedTimestampUtc = pg.CreatedDateUtc, pg.DocumentType, pg.OpportunityId }
                where o.Id == "0067000000hUBRUAA4"
                select new {
                    CreatedTimestampUtc = pg.CreatedDateUtc,
                    pg.DocumentType,
                    PhotoFull = p.Full,
                    OpportunityName = o.Name
                }.GroupBy(t => new { t.OpportunityName, t.DocumentType, t.CreatedTimestampUtc });
    
    
    var fetchedItems = items.ToList();
    foreach(var item in items)
    {
        Console.WriteLine(item.Key.OpportunityName);
        Console.WriteLine(item.Key.DocumentType);
        Console.WriteLine(item.Key.CreatedTimestampUtc);
    
        foreach(var photo in item)
        {
            Console.WriteLine(photo.PhotoFull);
        }
    }
