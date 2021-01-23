		[System.Web.Services.WebMethod]
		public static string web_method(string param1, string param_n)
		{
		string strerror = "0", strmessage = "";
		try
		{
			strerror = "0";
		}
		catch (Exception ex)
		{
			strerror = "2";
			strmessage = ex.Message;
		}
		return "{\"err\":\"" + strerror + "\",\"msg\":\"" + strmessage + "\"}";
		}
