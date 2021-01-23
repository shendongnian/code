    static void Main(string[] args)
    {
       BaseItem item = new Item();
       Console.WriteLine(GetBaseType<Item>().Name); // BaseItem
       Console.WriteLine(GetImplementerType(item).Name); // Item
    }
    static Type GetBaseType<T>()
    {
       return typeof(T).BaseType;
    }
    static Type GetImplementerType(object obj)
    {
       return obj.GetType();
    }
