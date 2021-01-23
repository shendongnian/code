    public static async Task MainAsync()
    {
        var my_files = new file_prep_obj();
        my_files.get_files();
        const int userSuppliedMaxThread = 5;
        var maxThreads = Math.Min(userSuppliedMaxThread, my_files.my_dictionary.Values.Count());
        Console.WriteLine("MaxThreads = " + maxThreads);
        foreach (var pair in my_files.my_dictionary)
        {
            foreach (var path in pair.Value)
            {
                Console.WriteLine("Key= {0}, Value={1}", pair.Key, path);   
            }            
        }
        await my_files.my_dictionary.ForEachAsync(maxThreads, async (pair) =>
        {
            foreach (var path in pair.Value)
            {
                // serially process each path for a particular host.
                await process_file(path);
            }
        });
    }
    static void Main(string[] args)
    {
        MainAsync().Wait();
        Console.ReadKey();
    }//Close static void Main(string[] args)
    
