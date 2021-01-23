    public static async Task<ServiceReturnModel> HttpGetForJson (string url)
		{
			using (var client = new HttpClient(new NativeMessageHandler())) 
			{
				try
				{
					using (var response = await client.GetAsync(new Uri (url))) 
					{
						using (var responseContent = response.Content) 
						{
							var responseString= await responseContent.ReadAsStringAsync();
							var result =JsonConvert.DeserializeObject<ServiceReturnModel>(responseString);
						}
					}
				}
				catch(Exception ex) 
				{
                   // Include error info here
				}
				return result;
			}
		}
