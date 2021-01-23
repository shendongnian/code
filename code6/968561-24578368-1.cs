    // GET api/Foo
    public HttpResponseMessage GetFoos()
    {
        var foos = GetAListOfFoosFromSomewhere(); //returns an IQueryable<Foo>
        var settings = new JsonSerializerSettings()
        {
         ContractResolver= new MyCustomContractResolver(), //Put  your custom implementation here
         //Also set up ReferenceLoopHandling as appropiate
        };
        var jsoncontent = JsonConvert.SerializeObject(foos, settings);
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(jsoncontent, Encoding.UTF8, "application/json")
        };
        return response;
    }
