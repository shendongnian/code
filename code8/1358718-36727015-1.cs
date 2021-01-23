    var data = _db.tblVisitors
        .GroupBy(v => new { v.vLat, v.vLong })
        .Select(grp => new 
            {
                grp.Key.vLat,
                grp.Key.vLong,
                Count = grp.Count()
            })
        .AsEnumerable()
        .Select(x => new new VisitorMapViewModel()
            {
                coords = new System.Device.Location.GeoCoordinate(
                    double.Parse(x.vLat), 
                    double.Parse(x.vLong)),
                count = x.Count
            })
        .ToList();
                
