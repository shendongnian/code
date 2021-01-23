    public class ProvidersViewModel : IEqualityComparer<ProvidersViewModel>
    {
        public bool Equals(ProvidersViewModel x, ProvidersViewModel y)
        {
            if (x.col1 == y.col1 && x.col2 == y.col2 && x.col3 == y.col3)
                return true;
            else
                return false;
        }
        
        public int GetHashCode(ProvidersViewModel obj)
        {
            int hCode = obj.col1 ^ obj.col2 ^ obj.col3;
            return hCode.GetHashCode();
        }
        // Existing code, fields, etc.
    }
