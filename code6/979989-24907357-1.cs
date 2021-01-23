    public class StoreSettingsEqualityComparer : IEqualityComparer<StoreSettings>
    {
        public bool Equals(StoreSettings x, StoreSettings y)
        {
            if (object.ReferenceEquals(x, null))
                return object.ReferenceEquals(y, null);
            return
                x.AutoAOD == y.AutoAOD &&
                x.AutoGRN == y.AutoGRN &&  
                ...
        }
        public int GetHashCode(StoreSettings obj)
        {
            unchecked
            {
                var h = 31;
                h = h * 7 + obj.AutoAOD.GetHashCode();
                ...
                return h;
            }
        }
    }
