    var product2 = new
    {
        Now = DateTime.Now,
        Sometime = new DateTime(2014, 10, 11, 0, 0, 0),
        SometimeLocal = new DateTime(2014, 10, 11, 0, 0, 0, DateTimeKind.Local),
        SometimeUtc = new DateTime(2014, 10, 11, 0, 0, 0, DateTimeKind.Utc)
    };
    string json2 = JsonConvert.SerializeObject(product2, Formatting.Indented);
    Console.WriteLine(json2);
