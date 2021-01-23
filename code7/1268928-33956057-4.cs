    public class FolderPathComparer : IEqualityComparer<FolderPath>
    {
        public bool Equals(FolderPath x, FolderPath y)
        {
            if (x != null)
            {
                if (y != null) return x.Path == y.Path;
                return false;
            }
            if (y != null) return false;
            return true;
        }
        public int GetHashCode(FolderPath obj)
        {
            if (obj == null || obj.Path == null) return 0;
            return obj.Path.GetHashCode();
        }
    }
