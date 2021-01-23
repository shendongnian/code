        public async Task <APIResponse> GetDataFromAPI(string query){
        			try
        			{
        				var client = new System.Net.Http.HttpClient ();
        				client.BaseAddress = "http://domain/";
    				var response = await client.GetAsync("plan/web/get"+query);
    
    				response.EnsureSuccessStatusCode();
    				var responseJSON = await response.Content.ReadAsStringAsync();
    
    				var msg  = JsonConvert.DeserializeObject<APIResponse>(responseJSON);
    
    				return msg;
    			}
    
    			catch (Exception exc)
    			{
    				var msg = new APIResponse ();
    				msg.status = "failed";
    
    				return msg;
    			}
    
    }
