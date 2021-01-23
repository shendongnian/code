    public static class MyConvert
    {
        public static UInt64? ToUInt64OrNull(object value)
        {
            if(Convert.IsDBNull(value) || value == null)
            {
                return null;
            }
            else
            {
                return Convert.ToUInt64(value);
            }
    
        }
    }
