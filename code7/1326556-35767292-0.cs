    static void Main(string[] args)
    {
        System.DateTime cur = System.DateTime.UtcNow;
        string strDefault = cur.ToString();
        string str  = cur.ToString("yyyy-MM-ddTHH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
        System.Console.WriteLine(str);
        System.Console.WriteLine(strDefault);
    }
