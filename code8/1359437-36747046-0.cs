    void Main()
    {
        string[] decimals = new string[] { "30.00", "56.36", "200.00", "588888.00" };
    
        foreach (var dec in decimals.OrderBy(x => x, new DecimalComparer()))
        {    
            Console.WriteLine(thing);
        }
    }
    
    
    public class DecimalComparer: IComparer<string>
    {
        public int Compare(string s1, string s2)
        {
            if (IsDecimal(s1) && IsDecimal(s2))
            {
                if (Convert.ToDecimal(s1) > Convert.ToDecimal(s2)) return 1;
                if (Convert.ToDecimal(s1) < Convert.ToDecimal(s2)) return -1;
                if (Convert.ToDecimal(s1) == Convert.ToDecimal(s2)) return 0;
            }
    
            if (IsDecimal(s1) && !IsDecimal(s2))
                return -1;
    
            if (!IsDecimal(s1) && IsDecimal(s2))
                return 1;
    
            return string.Compare(s1, s2, true);
        }
    
        public static bool IsDecimal(object value)
        {
            try {
                int i = Convert.ToDecimal(value.ToString());
                return true; 
            }
            catch (FormatException) {
                return false;
            }
        }
    }
