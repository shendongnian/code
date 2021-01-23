    public async Task<ActionResult<string>> ObtainData(string url, CancellationToken ct = default(CancellationToken))
    {            
       Result<string> result = new Result<string>();
       try
       {
           var request = (HttpWebRequest) WebRequest.Create(url);
	       request.Method = "GET";
           HttpResponseMessage response = await httpClient.SendAsync(request); //HttpClient
           httpClient.TimeOut = int.MaxValue; // change this as you like
           string jsonresult = await HandleReceipt(response, type);
           result.Result = jsonresult;
       } 
       catch (Exception ex)
       {
          result.Message = "Problem obtaining data.";
       }
 
       return result;
    }
