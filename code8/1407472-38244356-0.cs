    public static class Helpers
    {
        public static T GetSmartValue<T>(this SqlDataReader r, int ordinal)
        {
            dynamic value = r.GetValue(ordinal);
            if (value == DBNull.Value)
            {
                value = null;
                return value;
            }
            return (T) value;
        }
    }
