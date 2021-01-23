    public static string GetInfoStringUnhandled(OdbcConnection ocn, ushort info)
    {
    	MethodInfo GetInfoStringUnhandled = ocn.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).First(c => c.Name == "GetInfoStringUnhandled");
    	return Convert.ToString(GetInfoStringUnhandled.Invoke(ocn, new object[] { (ushort)info }));            
    }
    
    public static void Main(string[] args)
    {
    	OdbcConnection ocn = new OdbcConnection("DSN=GENESIS");
    	ocn.Open();
    	Console.WriteLine(GetInfoStringUnhandled(ocn, (ushort)10003)); //SQL_CATALOG_NAME returns Y
    }
