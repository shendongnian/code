    public class FileParametersComparer : IEqualityComparer<FileDetails>
    {
        public bool Equals(FileDetails x, FileDetails y)
        {
            return x.Name.Equals(y.Name, StringComparison.OrdinalIgnoreCase);
        }
        public int GetHashCode(FileDetails obj)
        {
            return obj.Name.GetHashCode();
        }
    }
