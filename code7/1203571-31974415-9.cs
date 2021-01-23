    public static string GetMike(string parCode) 
    {
    	if (parCode == null)
    		throw new ArgumentNullException("parCode", "parCode cannot be a null reference");
    
        string r = null;
    	using (var db = new YourDbContext())
    	{
    		r = db.Mike(parCode).First();
    	}
    	return r;
    }
