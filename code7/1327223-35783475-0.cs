    public async Task<ActionResult> Contact()
    {
        var req = WebRequest.Create(@"yourApiEndpointUrlHere");    
        var r = await req.GetResponseAsync().ConfigureAwait(false);              
    
        var responseReader = new StreamReader(r.GetResponseStream());
        var responseData = await responseReader.ReadToEndAsync();
    
        var d = Newtonsoft.Json.JsonConvert.DeserializeObject<MyData>(responseData);    
        return View(d);
    }
