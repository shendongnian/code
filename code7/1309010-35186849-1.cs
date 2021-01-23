    var distincts = 
        combinations
        .Distinct(new ListOfIntComparer());    
    
    class ListOfIntComparer : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int> a, List<int> b)
        {
            return
                a.SequenceEqual(b);
        }
    
        public int GetHashCode(List<int> l)
        {
            unchecked
            {
                int hash = 19;
                foreach (var foo in l)
                {
                    hash = hash * 31 + foo.GetHashCode();
                }
                return hash;
             }
        }
    }
