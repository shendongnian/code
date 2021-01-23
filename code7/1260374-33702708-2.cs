    static void Main(string[] args)
    {
        foreach (var s in GetStates())
        {
            Console.WriteLine(s);
        }
    }
    public static IEnumerable<string> GetStates()
    {
        var lst = new List<string>();
        lst.Add("Alabama");
        lst.Add("Alaska");
        lst.Add("Arizona");
        ...
        return lst;
    } 
