		public static T RetrieveContent<T>(string url)
		{
			if (String.IsNullOrWhiteSpace(url))
				throw new ArgumentNullException("url");
            T returnValue = default(T);
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				request.Method = "GET";
				request.ContentType = "application/x-www-form-urlencoded";
				request.Accept = "application/json; charset=utf-8";
				using (WebResponse response = request.GetResponse())
				{
					if (response != null)
					{
						using (StreamReader reader = new StreamReader(response.GetResponseStream()))
						{
                            var serializer = new JsonSerializer();
                            var jsonTextReader = new JsonTextReader(reader);
                            returnValue = serializer.Deserialize<T>(jsonTextReader);
                        }
					}
				}
			}
			catch (Exception e)
			{
				string errMsg = String.Format("UtilitiesBL:RetrieveContent<T>(url). There was an error retrieving content from URL: {0}.", url);
				throw new Exception(errMsg, e);
			}
			return returnValue;
		}
		public static T RetrieveContentPost<T>(string url, string postData)
		{
			if (String.IsNullOrWhiteSpace(url))
				throw new ArgumentNullException("url");
			T returnValue = default(T);
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				byte[] contentBytes = Encoding.UTF8.GetBytes(postData);
				request.Method = "POST";
				request.ContentType = "application/x-www-form-urlencoded";
				request.ContentLength = contentBytes.Length;
				request.Accept = "application/json; charset=utf-8";
				// Get the request stream.
				using(Stream dataStream = request.GetRequestStream())
				{
					// Write the data to the request stream.
					dataStream.Write(contentBytes, 0, contentBytes.Length);
				}
				using (WebResponse response = request.GetResponse())
				{
					if (response != null)
					{
						using (StreamReader reader = new StreamReader(response.GetResponseStream()))
						{
                            var serializer = new JsonSerializer();
                            var jsonTextReader = new JsonTextReader(reader);
                            returnValue = serializer.Deserialize<T>(jsonTextReader);
                        }
					}
				}
			}
			catch (Exception e)
			{
				string errMsg = String.Format("UtilitiesBL:RetrieveContentPost(url, postData). There was an error retrieving content from URL: {0}.", url);
				throw new Exception(errMsg, e);
			}
			return returnValue;
		}
