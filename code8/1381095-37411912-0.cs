    public static void Main(string[] args)
    {
        var objects = new List<DateTime>();
    
        objects.Add(DateTime.Now.AddDays(1));
        objects.Add(DateTime.Now.AddDays(1));
        objects.Add(DateTime.Now.AddDays(2));
        objects.Add(DateTime.Now.AddDays(2));
        objects.Add(DateTime.Now.AddDays(3));
        objects.Add(DateTime.Now.AddDays(3));
        objects.Add(DateTime.Now.AddDays(4));
        objects.Add(DateTime.Now.AddDays(4));
        objects.Add(DateTime.Now.AddDays(5));
        objects.Add(DateTime.Now.AddDays(5));
    
        objects.Distinct().ForEach(x => Console.WriteLine(x.ToShortDateString()));
    }
