    class CaseInsensitiveComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
        //Check whether the compared objects reference the same data.
        if (Object.ReferenceEquals(x, y)) return true;
        //Check whether any of the compared objects is null.
        if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
            return false;
            //Check whether the strings are equal, ignoring the case.
            return x.ToLower() == y.ToLower();
        }
        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
        public int GetHashCode(string s)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(s, null)) return 0;
            return s.GetHashCode();
        }
    }
