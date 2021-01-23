    private async Task<string> DeleteContact(string contactId)
    {
    	try
    	{
    		using (var client = new HttpClient())
    		{
    			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "<Replace with your oAuth Token>");
    			using (var request = new HttpRequestMessage(System.Net.Http.HttpMethod.Delete, "https://api.constantcontact.com/v2/contacts/" + contactId + "?api_key=<Replace with your API key>"))
    			{
    				using (var response = await client.SendAsync(request).ConfigureAwait(false))
    				{
    					response.EnsureSuccessStatusCode();
    					return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    				}
    			}
    		}
    	}
    	catch (Exception exp)
    	{ 
    		//log exp here
    	}
    	return string.Empty;
    }
