    var cities = new List<City>()
    foreach (var file in d.GetFiles("*.json"))
    {
      using (StreamReader fi = File.OpenText(file.FullName))
      {
        JsonSerializer serializer = new JsonSerializer();
        City city = (City)serializer.Deserialize(fi, typeof(City));
       cities.Add(city);
     }
    }
    using (StreamWriter file = File.CreateText(@"c:\cities.json"))
    {
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(file, cities);
    }
