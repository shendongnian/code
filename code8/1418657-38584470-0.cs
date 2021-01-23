     IList<ItemDTO> itemDTOs = dbItems
                .Select(dbItem => {
                    try
                    {
                        var value = itemPriceDict[dbItem.Id];
                    }
                    catch (KeyNotFoundException)
                    {//Breakpoint goes here
                    }
                    // Possible KeyNotFoundException
                    new ItemDTO()
                    {
                        Id = dbItem.Id,
                        Label = dbItem.Label,
                        PriceTag = itemPriceDict[dbItem.Id] // Possible KeyNotFoundException
                    };
                })
                .ToList();
