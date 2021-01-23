    var ReadJson = System.IO.File.ReadAllText(@"E:\C# Learning\POI.json");
    RootObject json = JsonConvert.DeserializeObject<RootObject>(ReadJson);
    foreach (var item in json.poi)
    {
        Console.WriteLine("name: {0}, shorttext : {1}, Latitutde: {2} , Latitutde: {3}, Image: {4}", item.Name, item.Shorttext, item.GeoCoordinates.Latitude, item.GeoCoordinates.Longitude, string.Join(" ", item.Images));
    }
