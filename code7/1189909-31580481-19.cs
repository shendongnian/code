    public class ReverseGuidEqualityComparer : IEqualityComparer<Guid>
    {
        public static readonly ReverseGuidEqualityComparer Default = new ReverseGuidEqualityComparer();
        public static readonly Func<Guid, int> GetHashCodeFunc;
        static ReverseGuidEqualityComparer()
        {
            var par = Expression.Parameter(typeof(Guid));
            var hash = Expression.Variable(typeof(int));
            var const23 = Expression.Constant(23);
            var const8 = Expression.Constant(8);
            var const16 = Expression.Constant(16);
            var const24 = Expression.Constant(24);
            var b = Expression.Convert(Expression.Convert(Expression.Field(par, "_b"), typeof(ushort)), typeof(uint));
            var c = Expression.Convert(Expression.Convert(Expression.Field(par, "_c"), typeof(ushort)), typeof(uint));
            var d = Expression.Convert(Expression.Field(par, "_d"), typeof(uint));
            var e = Expression.Convert(Expression.Field(par, "_e"), typeof(uint));
            var f = Expression.Convert(Expression.Field(par, "_f"), typeof(uint));
            var g = Expression.Convert(Expression.Field(par, "_g"), typeof(uint));
            var h = Expression.Convert(Expression.Field(par, "_h"), typeof(uint));
            var i = Expression.Convert(Expression.Field(par, "_i"), typeof(uint));
            var j = Expression.Convert(Expression.Field(par, "_j"), typeof(uint));
            var k = Expression.Convert(Expression.Field(par, "_k"), typeof(uint));
            var sc = Expression.LeftShift(c, const16);
            var se = Expression.LeftShift(e, const8);
            var sf = Expression.LeftShift(f, const16);
            var sg = Expression.LeftShift(g, const24);
            var si = Expression.LeftShift(i, const8);
            var sj = Expression.LeftShift(j, const16);
            var sk = Expression.LeftShift(k, const24);
            var body = Expression.Block(new[]
            {
                hash
            },
            new Expression[]
            {
                Expression.Assign(hash, Expression.Constant(37)),
                Expression.MultiplyAssign(hash, const23),
                Expression.AddAssign(hash, Expression.Field(par, "_a")),
                Expression.MultiplyAssign(hash, const23),
                Expression.AddAssign(hash, Expression.Convert(Expression.Or(b, sc), typeof(int))),
                Expression.MultiplyAssign(hash, const23),
                Expression.AddAssign(hash, Expression.Convert(Expression.Or(d, Expression.Or(se, Expression.Or(sf, sg))), typeof(int))),
                Expression.MultiplyAssign(hash, const23),
                Expression.AddAssign(hash, Expression.Convert(Expression.Or(h, Expression.Or(si, Expression.Or(sj, sk))), typeof(int))),
                hash
            });
            GetHashCodeFunc = Expression.Lambda<Func<Guid, int>>(body, par).Compile();
        }
        #region IEqualityComparer<Guid> Members
        public bool Equals(Guid x, Guid y)
        {
            return x.Equals(y);
        }
        public int GetHashCode(Guid obj)
        {
            return GetHashCodeFunc(obj);
        }
        #endregion
        // For comparison purpose, not used
        public int GetHashCodeSimple(Guid obj)
        {
            var bytes = obj.ToByteArray();
            unchecked
            {
                int hash = 37;
                hash = hash * 23 + (int)((uint)bytes[0] | ((uint)bytes[1] << 8) | ((uint)bytes[2] << 16) | ((uint)bytes[3] << 24));
                hash = hash * 23 + (int)((uint)bytes[4] | ((uint)bytes[5] << 8) | ((uint)bytes[6] << 16) | ((uint)bytes[7] << 24));
                hash = hash * 23 + (int)((uint)bytes[8] | ((uint)bytes[9] << 8) | ((uint)bytes[10] << 16) | ((uint)bytes[11] << 24));
                hash = hash * 23 + (int)((uint)bytes[12] | ((uint)bytes[13] << 8) | ((uint)bytes[14] << 16) | ((uint)bytes[15] << 24));
                return hash;
            }
        }
    }
