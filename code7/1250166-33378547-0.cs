    class MyComparer : IEqualityComparer<Dictionary<string,object>>
    {
        public bool Equals(Dictionary<string,object> b1, Dictionary<string,object> b2)
        {
            if (b2 == null && b1 == null)
               return true;
            else if (b1 == null || b2 == null)
               return false;
            else if(b1["W"]==b2["W"] && b1["X"]==b2["X"] && b1["X"]==b2["X"])
                return true;
            else
                return false;
        }
    
        public int GetHashCode(Dictionary<string,object> bx)
        {
            int hCode = bx["W"] ^ bx["X"] ^ bx["Y"];
            return hCode.GetHashCode();
        }
    }
