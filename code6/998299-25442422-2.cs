            public static WebExceptionStatus processResponse(HttpWebRequest response, out JsonValue values)
			{
				try
				{
					using (WebResponse stream = response.GetResponse())
					{
						using (StreamReader reader = new StreamReader(stream.GetResponseStream()))
						{
							values = JsonObject.Parse (reader.ReadToEnd ());
							return WebExceptionStatus.Success;
						}
					}
				}
				catch (WebException exception) {
					values = null;
					return exception.Status;
				}
			}
...
			HttpWebRequest request = HttpWebRequest.Create ("myURL") as HttpWebRequest;
			request.Headers["SOMEH_HAEDER_VALUE"] = applicationID;
			request.Method = "GET";
			request.ContentType = "application/json";
			JsonValue values;
			status = RequestDriver.processResponse (request, out values);
		
            if (RequestDriver.HadException (status)) {
				ExceptionHandler.handleNetworkException(status);
			}
			if (values ["results"].Count == 0) {
				return null;
			}
			JsonValue userValue = values ["results"] [0];
			string name = RequestDriver.stripQuotes( userValue["Name"].ToString() );
			string objectId = RequestDriver.stripQuotes( userValue["objectId"].ToString() );
			User user = new User (name, email, objectId);
			return user;
