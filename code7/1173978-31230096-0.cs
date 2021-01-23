    private string genHMAC(string secret, string url)
    {
    	var hmac = new HMACSHA512(Encoding.ASCII.GetBytes(secret));
    	var messagebyte = Encoding.ASCII.GetBytes(url);
    	var hashmessage = hmac.ComputeHash(messagebyte);
    	var sign = BitConverter.ToString(hashmessage).Replace("-", "");
    			
    	return sign;
    }
