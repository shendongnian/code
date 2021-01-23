    var result =
        Context
        .LocationItemQuantities
        .Where(x=> x.Location.DepotId == depotId)
        .GroupBy(x => x.Location.Name)
        .Select(x => new LocationDTO
        { 
            LocationName = x.Key,
            StatusItemDTOs = x.Select(y => new StatusItemDTO
            {
                DepotQuantity = y.Quantity,
                StandardQuantity = y.StandardQuantity,
                MinimumQuantity = y.MinQuantity,
                ItemTypeName = y.ItemType.Name
            }).ToList()
        })
        .ToList();
