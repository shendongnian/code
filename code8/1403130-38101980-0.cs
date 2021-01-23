    public class DirectoryInfoComparer : IEqualityComparer<DirectoryInfo>   
    {
        bool IEqualityComparer<DirectoryInfo>.Equals(DirectoryInfo x, DirectoryInfo y)
        {            
            return (x.Name == y.Name) && (x.Parent.Name == y.Parent.Name);        
        }
        int IEqualityComparer<DirectoryInfo>.GetHashCode(DirectoryInfo obj)
        {
            if (Object.ReferenceEquals(obj, null))
                return 0;               
            return obj.GetHashCode();       
        }
    }
