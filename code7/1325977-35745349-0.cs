    public class SqlHelper
    {
        private static Dictionary<Type, SqlType> typeMap;
        
        // Create and populate the dictionary in the static constructor
        static SqlHelper()
        {
            typeMap = new Dictionary<Type, SqlDbType>();
    
            typeMap[typeof(string)] = SqlDbType.NVarChar;
            /* ... and so on ... */
        }
        
        public static SqlDbType ConvertiTipo(Type giveType)
        {
            return typeMap[(giveType)];
        }
    }
