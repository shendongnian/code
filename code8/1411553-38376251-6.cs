    public class ItemByKeyEqualityComparer : IEqualityComparer<object>
    {
        private readonly PropertyInfo _keyProperty;
        public ItemByKeyEqualityComparer(PropertyInfo keyProperty)
        {
            _keyProperty = keyProperty;
        }
        public bool Equals(object x, object y)
        {
            var kx = _keyProperty.GetValue(x);
            var ky = _keyProperty.GetValue(y);
            if (kx == null)
            {
                return (ky == null);
            }
            return kx.Equals(ky);
        }
        public int GetHashCode(object obj)
        {
            var key = _keyProperty.GetValue(obj);
            return (key == null ? 0 : key.GetHashCode());
        }
    }
