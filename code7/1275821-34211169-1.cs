    [HttpPost]
    public async Task<HttpResponseMessage> Post([FromBody] List<JObject>     lstData)
    {
      return await PostMethod(lstData);
    }
    async Task<HttpResponseMessage> PostMethod(List<JObject> lstData)
    {
     //do somework
     await Method1();
     return myResult;
    }
    async Task Method1()
    {
       await Method2();
    }
    async Task Method2()
    {
     //do some work
     await Task.Delay(25);
    }
