    static class Extension
    {
        public static byte ToByte(this BitArray bits)
        {
            if (bits.Count != 8)
            {
                throw new ArgumentException("incorrect number of bits");
            }
            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            return bytes[0];
        }
        static class EnumConverter<TEnum> where TEnum : struct, IConvertible
        {
            public static readonly Func<long, TEnum> Convert = GenerateConverter();
            static Func<long, TEnum> GenerateConverter()
            {
                var parameter = Expression.Parameter(typeof(long));
                var dynamicMethod = Expression.Lambda<Func<long, TEnum>>(
                    Expression.Convert(parameter, typeof(TEnum)),
                    parameter);
                return dynamicMethod.Compile();
            }
        }
        public static T ToEnum<T>(this byte b) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            return EnumConverter<T>.Convert(b);
        }
    }
