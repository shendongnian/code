    public static void RenderOutput(IEnumerable<object> collection)
    {
        RenderHeader(collection.First()); //collection not validated
        collection.ToList().ForEach(item => RenderBody(item));
    }
    private static void RenderHeader(object obj)
    {
        var properties = obj.GetType().GetProperties().OrderBy(p => p.Name);
        Console.WriteLine("");
        foreach (var prop in properties)
        {
            Console.Write(prop.Name + "\t");
        }
    }
    private static void RenderBody(object obj)
    {
        var properties = obj.GetType().GetProperties().OrderBy(p => p.Name);
        Console.WriteLine("");
        foreach (var prop in properties)
        {
            Console.Write((prop.GetValue(obj, null)) + "\t");
        }
    }
