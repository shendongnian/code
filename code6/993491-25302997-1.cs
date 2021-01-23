    static void Main(string[] args)
    {
        var a = new[] { "A", "B" };
        var b = new[] { "1", "2", "3" };
        var c = new[] { "x", "y", "z", "w" };
    
        var result = Merge(a, b, c);
        foreach (var r in result)
        {
            Console.WriteLine(r);
        }
    }
    
    public static IList<string> Merge(params IEnumerable<string>[] lists)
    {
        return Merge((IEnumerable<IEnumerable<string>>) lists);
    }
    
    public static IList<string> Merge(IEnumerable<IEnumerable<string>> lists)
    {
        var retval = new List<string>();
        var first = lists.FirstOrDefault();
        if (first != null)
        {
            var result = Merge(lists.Skip(1));
            if (result.Count > 0)
            {
                foreach (var x in first)
                {                
                    retval.AddRange(result.Select(y => string.Format("{0}_{1}", x, y)));
                }
            }                
            else
            {
                retval.AddRange(first);
            }            
        }
    
        return retval;
    }
