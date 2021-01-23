    public static class Extensions
    {
        public static DateTime? Dob(this string strLine)
        {
            DateTime result;
            if(DateTime.TryParseExact(strLine, "dd/MM/yyyy",System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal,out result))
            {
                return result;
            }
            else 
            {
                return null;
            }
        }
    }
