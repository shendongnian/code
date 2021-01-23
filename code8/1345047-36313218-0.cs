    public static class Extensions
    {
        public static bool Contains(this string value, string search)
        {
            if(value != null)
            {
                return value.Contains(search);
                    
            }
            else
            {
                // IF ITS NULL DEFINE YOUR RETURN HERE
            }
            return false;
        }
    
        public static int IndexOf(this string value, string search)
        {
            if(value != null)
            {
                return value.IndexOf(search);
            }
            else
            {
                // IF ITS NULL DEFINE YOUR RETURN HERE
            }
            return -1;
        }
    }
