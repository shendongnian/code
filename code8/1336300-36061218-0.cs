    static void Main()
    {
        Dictionary<string, int> source = new Dictionary<string, int>();
        Dictionary<string, int> destination = new Dictionary<string, int>();
        destination.Add("Apple", 1);
        destination.Add("Banana", 2);
        foreach (var item in destination)
        {
            source.Add(item.Key, item.Value);
        }
        foreach (var item in destination)
        {
            Console.WriteLine("Key is {0} and value is {1}", item.Key, item.Value);
        }       
    }
