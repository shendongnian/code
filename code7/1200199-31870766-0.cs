    public byte[] CalculateHMAC(string data, string secret)
		{
			HMAC hmacSha256 = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
			byte[] dataBytes = Encoding.UTF8.GetBytes(data);
			byte[] hmac2Hex = hmacSha256.ComputeHash(Encoding.UTF8.GetBytes(data));
		 
			string hex = BitConverter.ToString(hmac2Hex);
			hex = hex.Replace("-","").ToLower();
			byte[] hexArray = Encoding.UTF8.GetBytes(hex);
			return hexArray;
		}
		
	protected void Button1_Click(object sender, EventArgs e)
    {                     
		string jsonString = "{ \"merchant_ref\": \"MVC Test\", \"transaction_type\": \"authorize\", \"method\": \"credit_card\", \"amount\": \"1299\", \"currency_code\": \"USD\", \"credit_card\": { \"type\": \"visa\", \"cardholder_name\": \"Test Name\", \"card_number\": \"4005519200000004\", \"exp_date\": \"1020\", \"cvv\": \"123\" } }";
		Random random = new Random();
		string nonce = (random.Next(0, 1000000)).ToString();
		DateTime date = DateTime.UtcNow;
		DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		TimeSpan span = (date - epoch);
		string time = span.TotalSeconds.ToString();
		
		string token = Request.Form["token"];//Merchant token
		string apiKey = Request.Form["apikey"];//apikey
		string apiSecret = Request.Form["apisecret"];//API secret
		string hashData = apiKey+nonce+time+token+jsonString;
		
		string base64Hash = Convert.ToBase64String(CalculateHMAC(hashData, apiSecret));
		
		string url = "https://api-cert.payeezy.com/v1/transactions";
	   
		//begin HttpWebRequest
		HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
		webRequest.Method = "POST";
		webRequest.Accept = "*/*";
		webRequest.Headers.Add("timestamp", time);
		webRequest.Headers.Add("nonce", nonce);
		webRequest.Headers.Add("token", token);
		webRequest.Headers.Add("apikey", apiKey);
		webRequest.Headers.Add("Authorization", base64Hash );
		webRequest.ContentLength = jsonString.Length;
		webRequest.ContentType = "application/json";
		StreamWriter writer = null;
		writer = new StreamWriter(webRequest.GetRequestStream());
		writer.Write(jsonString);
		writer.Close();
		string responseString;
		try
			{
				using(HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
				{
					using (StreamReader responseStream = new StreamReader(webResponse.GetResponseStream()))
					{
						responseString = responseStream.ReadToEnd();
						request_label.Text = "<h3>Request</h3><br />" + webRequest.Headers.ToString() + System.Web.HttpUtility.HtmlEncode(jsonString);
						response_label.Text = "<h3>Response</h3><br />" + webResponse.Headers.ToString() + System.Web.HttpUtility.HtmlEncode(responseString);
					}
				}
			}
		catch (WebException ex)
		{
			if (ex.Response != null) 
			{
				using (HttpWebResponse errorResponse = (HttpWebResponse)ex.Response) 
				{
					using (StreamReader reader = new StreamReader(errorResponse.GetResponseStream())) 
					{
						string remoteEx = reader.ReadToEnd();
						error.Text = remoteEx;
					}
				}
			}           
		}
	}
        
