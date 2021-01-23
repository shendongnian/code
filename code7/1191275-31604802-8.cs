    public static List<string> CreateList()
    {
        return new List<string>();
    }
    public static List<string> AddItem(this List<string> list, string item)
    {
        list.Add(item);
        return list;
    }
    public static List<string> DoSomethingWithList(this List<string> list)
    {
        ...;
        return list;
    }
