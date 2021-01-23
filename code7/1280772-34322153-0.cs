    static ConcurrentDictionary<int, object> listThingy = new ConcurrentDictionary<int, object>();
    
    static void Main(string[] args)
    {
        listThingy.Add(1, null);
        listThingy.Add(2, null);
        foreach (var item in listThingy)
        {
            object val = null;
            listThingy.TryAdd(3, null);
            listThingy.TryRemove(2, val);
            Console.WriteLine(item);
        }
    }
