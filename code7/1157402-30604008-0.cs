    Message result = null;
	try
	{
		result = _client.ProcessRequest(requestMessage);
	}
	catch (CommunicationException ex)
	{
		if (ex.InnerException == null ||
			!(ex.InnerException is WebException))
		{
			throw new WebFaultException<string>("An unknown internal Server Error occurred.",
				HttpStatusCode.InternalServerError);
		}
		else
		{
			var webException = ex.InnerException as WebException;
			var webResponse = webException.Response as HttpWebResponse;
			if (webResponse == null)
			{
				throw new WebFaultException<string>(webException.Message, HttpStatusCode.InternalServerError);
			}
			else
			{
				var responseStream = webResponse.GetResponseStream();
				string message = string.Empty;
				if (responseStream != null)
				{
					using (StreamReader sr = new StreamReader(responseStream))
					{
						message = sr.ReadToEnd();
					}
					throw new WebFaultException<string>(message, webResponse.StatusCode);
				}
				else
				{
					throw new WebFaultException<string>(webException.Message, webResponse.StatusCode);                            
				}
			}
		}
	}
