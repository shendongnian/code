    public static void update(Dictionary<int, string> array)
    {
        Debugger.Break(); // look at the contents of array here
        array = new Dictionary<int, string>();
        array[0] = "myself";
        array[1] = "version2";
        Debugger.Break(); // look at the contents of array here
    }
    public static void Main()
    {
        var foo = Dictionary<int, string>();
        foo[0] = "aap";
        update(foo);
        Debugger.Break(); // look at the contents of foo here
    }
