    foreach (var item in json.poi)
    {
        POI obj = new POI()
        {
            Name = item.Name,
            Shorttext = item.Shorttext,
            GeoCoordinates = item.GeoCoordinates,
            Images = item.Images
        };
        mycities.Add(obj);
    }
