    [HttpGet]
    public async Task<string> GetCAPTCHAImage(string username)
    {
    	try
    	{
    		return Convert.ToBase64String(GenerateCaptcha(username, 40, 50));
    	}
    	catch
    	{
    		return String.Empty;
    	}
    }
