    public static string SomeMethod(IEnumerable<Tuple<Regex, string>> tuples, string str)
    {
        foreach (var rr in tuples)
        {
            if (rr.Item1.IsMatch(str))
            {
                string replaced = rr.Item1.Replace(str, rr.Item2);
                return replaced;
            }
        }
        return str;
    }
    var dictionary = new[] 
    {
        Tuple.Create(new Regex("SPROC:(.*)"), "$1"),
        Tuple.Create(new Regex(@"onClick='(.*)\(this\)'"), "$1"),
    };
    string replaced = SomeMethod(dictionary, "SPROC:my_sproc");
