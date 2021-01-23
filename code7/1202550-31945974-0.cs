    static void Main(string[] args)
    {
        var enquiry = new InquireDatabaseAsync().DoWork();
        while (!enquiry.IsCompleted)
        {
            Console.WriteLine("Doing Stuff on the Main Thread...");
        }
        
        // In case there were any exceptions.
        enquiry.Wait();
    }      
