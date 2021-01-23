    private List<string> a = new List<string>();
    private List<string> b = new List<string>();
    private List<string> c = new List<string>();
    private Dictionary<string, List<string>> lists = new Dictionary<string, List<string>>();  
    lists.Add("a", a);
    lists.Add("b", b);
    lists.Add("q", c); // note that the key isn't related to the variable name.
