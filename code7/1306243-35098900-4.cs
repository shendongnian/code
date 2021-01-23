    public static Dictionary<string,double> modifiers()
    {
        Dictionary<string, double> lst = new Dictionary<string,double>();
        lst.Add("test1", 10.5);
        lst.Add("test2", 10.5);
        lst.Add("test3", 10.5);
        lst.Add("test4", 10.5);
        return lst;
    }
        var items = modifiers();
        double test1DoubleVal = items["test1"];
