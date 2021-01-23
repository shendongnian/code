    public static void Main(string[] args)
    {
         object o = 9.7000;
         CalculateThis(o);
    }
    public static decimal CalculateThis(object p)
    {
         if (p == null)
             return 0;
         else if (p == "")
             return 0;
         return Convert.ToInt16(p, CultureInfo.InvariantCulture);
    }
