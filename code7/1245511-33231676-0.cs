        public void Main()
        {
            var names = new string[] { "andy", "lisa", "zoro", "billy" };
    
            var result = FilterBetween(names, 'a', 'e');
        }
    
        public IEnumerable<string> FilterBetween(IEnumerable<string> names, char start, char end)
        {
            return names.
                Where(name => name.
                    First().
                    Between(start, end));
        }
    
    
    
    public static class ExtensionMethods
    {
        public static bool Between<T>(this T actual, T lower, T upper) where T : IComparable<T>
        {
            return actual.CompareTo(lower) >= 0 && actual.CompareTo(upper) <= 0;
        }
    }
