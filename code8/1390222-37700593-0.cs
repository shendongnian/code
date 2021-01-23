    public class DirComparator : IEqualityComparer<DirectoryInfo> {
    
        public bool Equals(DirectoryInfo x, DirectoryInfo y)
        {
    
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;
    
            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
    
            //Check whether the products' properties are equal.
            return x.Name.equals(y.Name);
        }
    
    	 public int GetHashCode(DirectoryInfo dir)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(dir, null)) return 0;
    
            //Get hash code for the Name field if it is not null.
            return dir.Name == null ? 0 : dir.Name.GetHashCode();
        }
    }
