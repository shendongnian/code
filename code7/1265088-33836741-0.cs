    using Microsoft.CSharp.RuntimeBinder;
    //...
    private static string ConcatAll<T>(T nestedList) where T : IList
    {
        string concat = "";
        dynamic templist = nestedList;
        try
        {
            while (true)
            {
                List<dynamic> inner = new List<dynamic>(templist).SelectMany<dynamic, dynamic>(x => x).ToList();
                templist = inner;
            }
        }
        catch (RuntimeBinderException)
        {
            List<object> l = templist;
            concat = l.Aggregate("", (a, b) => a + b);
            return concat;
        }
    }
