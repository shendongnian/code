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
            return obj.GetHashCode();
        }
    }
