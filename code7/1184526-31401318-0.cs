    public class MyComparer: IEqualityComparer<T>
    {
        public bool Equals(T o1,T o2)
        {
    		// They are the same object
            if (object.ReferenceEquals(o1, o2))
                return true;
    		// They are not the same
            if (o1 == null || o2 == null)
                return false;
    		// They have the same ID
            return o1.test1.Equals(o2.test1);
        }
    
        public int GetHashCode(X x)
        {
            return x.ID.GetHashCode();
        }
    }
