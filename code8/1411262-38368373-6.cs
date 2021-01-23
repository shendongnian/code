    public static class DtoRegistry
    {
        private static readonly Dictionary<Tuple<Type, int>, string> _sqlSelectByType =
            new Dictionary<Tuple<Type, int>, string>();
        public static void RegisterDto<T>(int appVersion, string sqlSelect) where T : IDataItem
        {
            var key = new Tuple<Type, int>(typeof(T), appVersion);
            _sqlSelectByType[key] = sqlSelect;
        }
        public static string GetSqlSelectFrom<T>(int appVersion) where T : IDataItem
        {
            var key = new Tuple<Type, int>(typeof(T), appVersion);
            return _sqlSelectByType[key];
        }
    }
