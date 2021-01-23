    [Route("test/{var1}/{var2}")]
    [AcceptVerbs("POST")]
    public ResultDataType Post(string var1, string var2) {           
        string data = Request.Content.ReadAsStringAsync().Result;
    }
