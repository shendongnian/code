    static void Main()
    {
        // No risk of deadlock, as a console app doesn't have a synchronization context
        RunSearches().Wait();
        Console.ReadLine();
    }
    static async Task RunSearches()
    {
        string keywords = "Driving Schools,wedding services";
        List<string> kwl = keywords.Split(',').ToList();
    
        foreach(var kw in kwl)
        {
            Output("SEARCHING FOR: " + kw);
            await Search(kw);
        }             
    }
    
    static async Task Search(string keyword)
    {
        // code for searching
    }
