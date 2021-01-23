    static void Main(string[] args)
    {
    	var sha1 = new System.Security.Cryptography.SHA1Managed();
    	var plaintextBytes = Encoding.UTF8.GetBytes("20150819100015.test.1002-4-2015.978.GBP");
    	var hashBytes = sha1.ComputeHash(plaintextBytes);
    
    	var sb = new StringBuilder();
    	foreach (var hashByte in hashBytes)
    	{
    		sb.AppendFormat("{0:x2}", hashByte);
    	}
    
    	var hashString = sb.ToString();
    }
