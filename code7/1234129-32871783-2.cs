    static void Main(string[] args)
    {
        string[] names = new string[] { "johnE", "samuel", "george", "steve", "martyn" };
        Console.WriteLine(string.Join(Environment.NewLine, names.Select(s => new string(s.Where(x => !"aeiou".Contains(x)).ToArray()))));
    }
