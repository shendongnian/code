    static void Main()
    {           
        TestAsync().Wait();
    }
    public static async Task TestAsync()
    {
        await Task.Run(() => 
        {
            var objectContext = new CommonEntities();
            Console.WriteLine("Processed");
        });
    }
