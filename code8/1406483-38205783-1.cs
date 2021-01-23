    static void Main()
    {
        var config = new MapperConfiguration(
            cfg =>
                {
                    cfg.CreateMap<A, B>();
                    cfg.CreateMap<DateTime, string>().ConvertUsing(dt => dt.ToString("u"));
                });
    
        var mapper = config.CreateMapper();
        
        var a = new A();
        
        Console.WriteLine(a.DateTime); // will print DateTime.ToString
        Console.WriteLine(mapper.Map<B>(a).DateTime); // will print DateTime in ISO string
        Console.ReadKey();
    }
