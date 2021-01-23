    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Newtonsoft.Json;
    using System.Threading.Tasks;
    
    //IStateInfo is my model class interface
    public async Task<IList<IStateInfo>> GetAllStatesAsync()
    {
    	List<IStateInfo> states = new List<IStateInfo>();
    	try
    	{
    		using (var client = new HttpClient())
    		{
    			client.BaseAddress = new Uri("http://YourBaseApiHere");
    			client.DefaultRequestHeaders.Accept.Clear();
    			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    			string url = "lookup/usstates";
    			HttpResponseMessage response = await client.GetAsync(url);
    			if (response.IsSuccessStatusCode)
    			{
    				var json = await response.Content.ReadAsStringAsync();
    				//deserialize into client class Newtonsoft JSON used here
    				var lst = JsonConvert.DeserializeObject<List<StateInfo>>(json);
    				states.AddRange(lst);
    			}
    			else
    			{
    				//notify of failed web call here
    			}
    		}
    	}
    	catch (Exception e)
    	{
    		//notify of error
    	}
    	return states;
    }
