    static void Main(string[] args)
    {
        var myList = MyListProxy.CreateProxy(new[] {"foo", "bar", "baz", "quxx"});
        var listType = myList.GetType();
        var interfaceType = listType.GetInterface("System.Collections.Generic.ICollection`1");
        var propInfo = interfaceType.GetProperty("Count");
        // TargetException thrown on 32-bit .Net 4.5.2+ installed
        int count = (int)propInfo.GetValue(myList, null); 
    }
