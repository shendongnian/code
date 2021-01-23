    public class ReverseGuidEqualityComparer : IEqualityComparer<Guid>
    {
        public static readonly ReverseGuidEqualityComparer Default = new ReverseGuidEqualityComparer();
        #region IEqualityComparer<Guid> Members
        public bool Equals(Guid x, Guid y)
        {
            return x.Equals(y);
        }
        public int GetHashCode(Guid obj)
        {
            var bytes = obj.ToByteArray();
            int hash = 37;
            unchecked
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    hash = hash * 23 + bytes[i].GetHashCode();
                }
            }
            return hash;
        }
        #endregion
    }
