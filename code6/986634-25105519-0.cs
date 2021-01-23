    var example = new
    {
        Now = DateTimeOffset.Now,
        UtcNow = DateTimeOffset.UtcNow,
        Sometime = new DateTimeOffset(2014, 10, 11, 1, 4, 9, new TimeSpan(8, 0, 0)),
        FromDateTime = new DateTimeOffset(new DateTime(2010, 1, 1)),
    };
    string json = JsonConvert.SerializeObject(example, Formatting.Indented);
    Console.WriteLine(json);
