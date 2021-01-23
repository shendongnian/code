	string uri = "https://www.mywebsite.com/customer/account/loginPost/";
	string html;
	
	using (var wc = new WebClient())
	{
		wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
		
		var nvc = new System.Collections.Specialized.NameValueCollection()
		{
			{ "form_key", "BaqsPklZGXt3Kq5o" },
			{ "login[username]", "user@domain.com" },
			{ "login[password]", "myfunkypassword" },
			{ "send", "" },
		};
		
		byte[] result = wc.UploadValues(uri, nvc);
		
		html = System.Text.Encoding.UTF8.GetString(result);
	}
