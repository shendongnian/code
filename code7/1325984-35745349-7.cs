    public static class SqlHelper
    {
        private static Dictionary<Type, SqlDbType> typeMap;
        // Create and populate the dictionary in the static constructor
        static SqlHelper()
        {
            typeMap = new Dictionary<Type, SqlDbType>();
            typeMap[typeof(string)]         = SqlDbType.NVarChar;
            typeMap[typeof(char[])]         = SqlDbType.NVarChar;
            typeMap[typeof(byte)]           = SqlDbType.TinyInt;
            typeMap[typeof(short)]          = SqlDbType.SmallInt;
            typeMap[typeof(int)]            = SqlDbType.Int;
            typeMap[typeof(long)]           = SqlDbType.BigInt;
            typeMap[typeof(byte[])]         = SqlDbType.Image;
            typeMap[typeof(bool)]           = SqlDbType.Bit;
            typeMap[typeof(DateTime)]       = SqlDbType.DateTime2;
            typeMap[typeof(DateTimeOffset)] = SqlDbType.DateTimeOffset;
            typeMap[typeof(decimal)]        = SqlDbType.Money;
            typeMap[typeof(float)]          = SqlDbType.Real;
            typeMap[typeof(double)]         = SqlDbType.Float;
            typeMap[typeof(TimeSpan)]       = SqlDbType.Time;
            /* ... and so on ... */
        }
        
        // Non-generic argument-based method
        public static SqlDbType GetDbType(Type giveType)
        {
            // Allow nullable types to be handled
            giveType = Nullable.GetUnderlyingType(giveType) ?? giveType;
            
            if (typeMap.ContainsKey(giveType))
            {
                return typeMap[giveType];
            }
            
            throw new ArgumentException($"{giveType.FullName} is not a supported .NET class");
        }
        
        // Generic version
        public static SqlDbType GetDbType<T>()
        {
            return GetDbType(typeof(T));
        }
    }
