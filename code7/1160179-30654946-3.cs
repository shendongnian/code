    public class StringListComparer : IEqualityComparer<List<string>>
    {
        public bool Equals(List<string> x, List<string> y)
        {
            return CompareLists(x, y);
        }
        public int GetHashCode(List<string> obj)
        {
            return base.GetHashCode();
        }
        private static bool CompareLists(List<string> x, List<string> y)
        {
            if (x.Count != y.Count)
                return false;
		
			// we HAVE to ensure that lists are in same order
			// for a proper comparison
			x = x.OrderBy(v => v).ToList();
			y = y.OrderBy(v => v).ToList();
            for (var i = 0; i < x.Count(); i++)
            {
                if (x[i] != y[i])
                    return false;
            }
            return true;
        }
    }
