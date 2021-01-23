    class ListEqCompare : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int> x, List<int> y)
        {
            if (x.Count != y.Count)
                return false;
            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] != y[i])
                    return false;
            }
            return true;
        }
        public int GetHashCode(List<int> obj)
        {
            int hash = 0;
            foreach (int num in obj)
                hash = hash ^ EqualityComparer<int>.Default.GetHashCode(num);
            
            return hash;
        }
    }
