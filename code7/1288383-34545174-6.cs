    public static List<A> GetValues(string file)
    {
        List<string> vals = new List<string>(Regex.Split(System.IO.File.ReadAllText(file), "--------------------"));
        vals.RemoveAll(delegate(string s) { return string.IsNullOrEmpty(s.Trim()); });
        List<A> ret = new List<A>();
        vals.ForEach(delegate(string s) { ret.Add(new A(s)); });
        return ret;
    }
    
    public static void Main()
    {
        foreach (A a in GetValues(@"C:\somefile.txt")) {
            Console.WriteLine(a);
        }
    }
