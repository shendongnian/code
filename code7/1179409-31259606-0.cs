    static async void GetValue()
    {
        var repo = new SchemePolicyRepository(new DbManager()); // creates an open connection 
        var result = await repo.GetById();
        Console.WriteLine(result);
    }
    static void Main(string[] args)
    {
        GetValue();   
        Console.WriteLine("Query is running...");
        Console.ReadKey();
    }
