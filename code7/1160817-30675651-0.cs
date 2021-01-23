	public void SendAndGetResponseString()
	{
		try
		{
			// Here you call your API
		}
		catch (WebException e)
		{
			var result = GetResponceFromWebException(e);
			if (result != null){
				// 
				// Here you could use the HttpStatusCode and HttpResponseMessage
				//
			}					
			throw;
		}
		catch (Exception e)
		{
			throw;
		}
	}
	
	
	private HttpRequestResponce GetResponceFromWebException(WebException e)
	{
		HttpRequestResponce result = null;
		if (e.Status == WebExceptionStatus.ProtocolError)
		{
			try
			{
				using (var stream = e.Response.GetResponseStream())
				{
					if (stream != null)
					{
						using (var reader = new StreamReader(stream))
						{
							var responseString = reader.ReadToEnd();
							var responce = ((HttpWebResponse) e.Response);
							
							result = new HttpRequestResponce(responseString, responce.StatusCode);
						}
					}
				}
			}
			catch (Exception ex)
			{
				// log exception or do nothing or throw it
			}
		}
		return result;
	}
	
	
	public class HttpRequestResponce {
		public HttpStatusCode HttpStatusCode { get;set; }
		public string HttpResponseMessage {get;set;}
	    
		public HttpRequestResponce() { }
		public HttpRequestResponce(string message, HttpStatusCode code)
        {
		      HttpStatusCode=code;
		      HttpResponseMessage=message;
		}
	}
