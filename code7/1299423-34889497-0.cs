    public static class DbNullExt
    {
        public static bool IsNullData(this object obj)
        {
            return obj == null || obj is DBNull;
        }
    }
