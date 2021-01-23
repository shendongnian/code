    var data = (from visitor in _db.tblVisitors
                group visitor by new { visitor.vLat, visitor.vLong } into grp
                select new 
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
