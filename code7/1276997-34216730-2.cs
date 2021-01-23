    [HttpGet]
    public HttpResponseMessage Test()
    {
        var person = new Person() { Id = 1, FirstName = "x", LastName = "y", Age = 20 };
        string excludeProperties= "FirstName,Age";
        string result = JsonConvert.SerializeObject(person, Formatting.None,
                        new JsonSerializerSettings
                        {
                            ContractResolver = new TestContractResolver() 
                            { 
                                ExcludeProperties = excludeProperties
                            }
                        });
        var response = this.Request.CreateResponse(HttpStatusCode.OK);
        response.Content = new StringContent(result, Encoding.UTF8, "application/json");
        return response;
    }
