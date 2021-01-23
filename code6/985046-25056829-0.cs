    public static class Extensions
    {
        public static IEnumerable<XElement> GetElements(
            this XElement foo, string x, string y)
        { 
            return foo.Where(m => m.Descendants(x).Any(v => v.Value.IndexOf(y)>-1))
        }
    }
