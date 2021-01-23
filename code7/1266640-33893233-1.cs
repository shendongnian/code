    [HttpPost, Route("customers/add")]
    public RestErrorHandler Add([FromBody]Models.Customer customer)
    {
            try
            {
              //do something...
                return new RestErrorHandler { Error = res.ErrorMessage, Location = MethodBase.GetCurrentMethod().Name };
            }
            catch (Exception ex)
            {
                return new RestErrorHandler { Error = ex.ToString(), Location = MethodBase.GetCurrentMethod().Name };
            }
    }
    
    [HttpPost, Route("customers/remove")]
    public RestErrorHandler Delete([FromBody]Models.Customer customer)
    {
            try
            {
                //do something
                return new RestErrorHandler { Error = res.ErrorMessage, Location = MethodBase.GetCurrentMethod().Name };
            }
            catch (Exception ex)
            {
                return new RestErrorHandler { Error = ex.ToString(), Location = MethodBase.GetCurrentMethod().Name };
            }
    }
    public void Configuration(IAppBuilder app)
    {
         var configuration = new HttpConfiguration();
         //for route attributes on controllers
         configuration.MapHttpAttributeRoutes();
    }
    var response = await client.PostAsync(string.Format("http://my_uri/api/customers/add"), contentPost;
