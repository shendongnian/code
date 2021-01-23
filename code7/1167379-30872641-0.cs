    public static class MyExtensions
    {
        public static bool MyMethod<T>(this IEnumerable<T> list, string term)
        {
            if(term == "-1")
              return false; // or true, whichever is your requirement.
            return list.Any(x => x == term);
        }
    }
