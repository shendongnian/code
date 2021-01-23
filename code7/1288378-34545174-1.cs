    public static List<A> GetValues(string text)
    {
        List<string> vals = new List<string>(Regex.Split(text, "--------------------"));
        vals.RemoveAll(delegate(string s) { return string.IsNullOrEmpty(s.Trim()); });
        List<A> ret = new List<A>();
        vals.ForEach(delegate(string s) { ret.Add(new A(s)); });
        return ret;
    }
    
    public static Main()
    {
        string file = @"C:\somefile.txt";
        foreach (A a in GetValues(System.IO.File.ReadAllText(@"C:\somefile.txt"))) {
            Console.WriteLine(a);
        }
    }
