    [HttpGet]
    [Route("accounts/{accountId}/stuff/")]
    public IHttpActionResult GetStuffForAccount(int accountId)
    {
      var queryString = this.Request.GetQueryNameValuePairs();
      
      var p1Val = queryString.SingleOrDefault(x => x.Key == "stuffAfterDate").Value;
      DateTime stuffAfterDate = (string.IsNullOrEmpty(p1Val)) ?  null : DateTime.ParseExact(p1Val, "yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture);
      
    
      //do your remaining code here
    }
