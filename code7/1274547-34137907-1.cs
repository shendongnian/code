    class ListComparer : IEqualityComparer<List<string>>
    {
        public bool Equals(List<string> x, List<string> y)
        {
            if (x == y) 
               return true ; 
            
           if (x == null || y == null) 
               return false ;
    
            // Order if you need
    
            return x.SequenceEqual(y) ; 
        }
    
        public int GetHashCode(List<string> obj)
        {
            if (obj == null)
               return 0;
            unchecked
            {
               return obj.Select(e => e.GetHashCode()).Aggregate(17, (a, b) => 23 * a + b);
            }
        }
    }
