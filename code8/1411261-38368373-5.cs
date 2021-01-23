    public static class DtoRegistry
    {
        private static readonly Dictionary<Type, string> _sqlSelectByType =
            new Dictionary<Type, string>();
        public static void RegisterDto<T>(string sqlSelect) where T : IDataItem
        {
            _sqlSelectByType[typeof(T)] = sqlSelect;
        }
        public static string GetSqlSelectFrom<T>() where T : IDataItem
        {
            return _sqlSelectByType[typeof(T)];
        }
    }
