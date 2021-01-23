    static void Main()
    {
        var data = new Dictionary<string, DateTime> // here is main problem
        {
            { "test", new DateTime(2016, 7, 6, 9, 33, 0) }
        };
    
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<DateTime, string>().ConvertUsing(dt => dt.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
        });
    
        var mapper = config.CreateMapper();
    
        Console.WriteLine(mapper.Map<string>(data["test"]));
        Console.WriteLine(mapper.Map<IDictionary<string, string>>(data)["test"]);
        Console.ReadKey();
    }
