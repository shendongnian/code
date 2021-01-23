    public string request(string url)
		{
			string responseText = "";
			HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
  
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			WebHeaderCollection header = response.Headers;
			var encoding = ASCIIEncoding.ASCII;
			using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
			{
				responseText = reader.ReadToEnd();
			}
			return responseText;
		}
