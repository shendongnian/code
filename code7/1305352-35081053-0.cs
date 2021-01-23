    var responseObj = new { message = "Successful", supervisorlist = users };
    resp = new HttpResponseMessage 
    		{ 
    			Content = new StringContent(JsonConvert.SerializeObject(responseObj), 
    											System.Text.Encoding.UTF8, "application/json") 
    		};
