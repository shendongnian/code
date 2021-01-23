    public class SqlHelper
    {
        private static Dictionary<Type, SqlDbType> typeMap;
        // Create and populate the dictionary in the static constructor
        static SqlHelper()
        {
            typeMap = new Dictionary<Type, SqlDbType>();
            typeMap[typeof(string)] = SqlDbType.NVarChar;
            /* ... and so on ... */
        }
        public static SqlDbType GetDbType(Type giveType)
        {
            if (typeMap.ContainsKey(giveType))
            {
                return typeMap[(giveType)];
            }
            throw new ArgumentException($"{giveType.FullName} is not a supported .NET class");
        }
    }
