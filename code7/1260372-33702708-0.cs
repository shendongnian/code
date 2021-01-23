    static void Main(string[] args)
    {
        foreach (var s in GenRandomState())
        {
            Console.WriteLine(s);
        }
    }
    public static Random rnd = new Random();
    public static IEnumerable<string> GenRandomState()
    {
        List<string> lst = new List<string>();
        lst.Add("Alabama");
        lst.Add("Alaska");
        lst.Add("Arizona");
        ...
        return lst.OrderBy(xx => rnd.Next());
    } // End GenRandomState
