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
            GuidToInt32 gtoi = new GuidToInt32 { Guid = obj };
            unchecked
            {
                int hash = 37;
                hash = hash * 23 + gtoi.Int32A;
                hash = hash * 23 + gtoi.Int32B;
                hash = hash * 23 + gtoi.Int32C;
                hash = hash * 23 + gtoi.Int32D;
                return hash;
            }
        }
        #endregion
        [StructLayout(LayoutKind.Explicit)]
        private struct GuidToInt32
        {
            [FieldOffset(0)]
            public Guid Guid;
            [FieldOffset(0)]
            public int Int32A;
            [FieldOffset(4)]
            public int Int32B;
            [FieldOffset(8)]
            public int Int32C;
            [FieldOffset(12)]
            public int Int32D;
        }
    }
