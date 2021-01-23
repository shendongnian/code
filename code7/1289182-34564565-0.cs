    var nearestItems = (from item in _db.Flats
                           select new listItem()
                           {
                               Price = item.Price,
                               Address = item.Address,
                               Bathroom = item.Bathroom,
                               BesprovodnoiInternet = item.BesprovodnoiInternet,
                               City = item.City,
                               FloorAll = item.FloorAll,
                               FloorCurrent = item.FloorCurrent,
                               Funiture = item.Funiture,
                               Kondicioner = item.Kondicioner,
                               PartyFree = item.PartyFree,
                               RoomQuantity = item.RoomQuantity,
                               TipArendy = item.TipArendy,
                               TV = item.TV,
                               FlatId = item.FlatID,
                           }).ToList();
