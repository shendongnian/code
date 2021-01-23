    public class FolderPath
    {
        ...
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            FolderPath other = obj as FolderPath;
            if (other == null) return false;
            
            //simple implementation, only compares Path
            return Path == other.Path;
        }
        public override int GetHashCode()
        {
            if (Path == null) return 0;
            return Path.GetHashCode();
        }
    }
