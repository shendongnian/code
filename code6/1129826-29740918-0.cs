    public static class Extensions
        {
            public static object DefaultIfDBNull(this object obj, object _default)
            {
                return obj == DBNull.Value ? _default : obj;
            }
        }
