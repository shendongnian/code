    internal static class ConstantsString
    {
        internal static string ToConstantsString(this string input)
        {
            try
            {
                Type t = typeof (Constants);
                return t.GetProperty(input).GetValue(t, null).ToString();
            }
            catch (Exception)
            {
                return "Error";
            }
        }
    }
