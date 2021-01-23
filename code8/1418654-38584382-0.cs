    IList<ItemDTO> itemDTOs = dbItems.Where(dbitem => dbitem.itemPriceDict[dbItem.Id] != null)
        .Select(dbItem => new ItemDTO()
        {
            Id = dbItem.Id,
            Label = dbItem.Label,
            PriceTag = itemPriceDict[dbItem.Id] // Possible KeyNotFoundException
        })
        .ToList();
