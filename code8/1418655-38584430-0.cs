    .Select(dbItem => 
        {
            return new ItemDTO()
            {
                Id = dbItem.Id,
                Label = dbItem.Label,
                PriceTag = itemPriceDict[dbItem.Id] // Possible KeyNotFoundException
            })
        }
        .ToList();
