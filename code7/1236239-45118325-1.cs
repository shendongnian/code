    const string lookup = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    
    static string GetRandomString(int length)
    {
    	if (lookup.Length > 256)
    		throw new Exception("Lookup must be <= 256 characters in length");
    	
    	var maxMultiples = (int)Math.Floor(256 / lookup.Length);
    	var exclusiveLimit = (lookup.Length * maxMultiples);
    	
        var sb = new StringBuilder();
        using (var provider = new RNGCryptoServiceProvider())
        {
    		var buffer = new byte[length];
            while (true)
            {
    			var remaining = length - buffer.Length;
    			if (remaining == 0)
    				break;
    
                provider.GetBytes(oneByte, 0 remaining);
    			
    			for	(int i = 0; i < remaining)
    			{
    				if (buffer[i] >= exclusiveLimit)
                    {
    					continue;
    				}
    				var index = buffer[i] % lookup.Length;
    				sb.Append(lookup[index]);
    			}
            }
        }
        return sb.ToString();
    }
