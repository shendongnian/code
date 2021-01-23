    // Collect flat items and add in List<>
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
    foreach(var item in nearestItems)
    {
        item.ImagesString = Directory.EnumerateFiles(Server.MapPath("~/Content/Prop/" + item.FlatId + "/"))
         .Select(fn => "~/Content/Prop/" + item.FlatId + "/" + Path.GetFileName(fn)).ToList();
    }
