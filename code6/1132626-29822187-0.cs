    using (HttpClient hc = new HttpClient())
    			{
    				var myModel = new Model()
    				{
    				prop1 = "prop1", prop2 = 1, prop3 = "prop3"
    				};
    				HttpResponseMessage response = await client.PostAsJsonAsync("api/Employee/", myModel);
    				if (response.IsSuccessStatusCode)
    				{
    					
    				}
    			}
