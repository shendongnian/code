    [Route("missions")]
    [HttpGet]
    public HttpResponseMessage SearchMissions() {
        //Get the parsed query string as a collection of key-value pairs.
        IEnumerable<KeyValuePair<string, string>> filters = this.Request.GetQueryNameValuePairs();
        
        //...
    }
