    public static class StringConverters 
    {
        public static Int32 ToInt32(this String number)
        {
            return Int32.Parse(
                number, 
                NumberStyles.Integer,           
                CultureInfo.CurrentCulture.NumberFormat);
        }
    }
