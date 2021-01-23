    public class SecurityContext
    {
        public string ApiKey {get;set;}
    }
    
    public class ResponseContext
    {
        public IHttpResponse Response{get;set;}
    }
    
    [Binding]
    public class CommonSteps
    {
         private SecurityContext securityContext;
         private ResponseContext responseContext;
         public CommonSteps(SecurityContext securityContext,ResponseContext responseContext)
        {
             this.securityContext = securityContext;
             this.responseContext = responseContext;
        }
    
        [Given(@"a valid API key is given")]
        public void AValidApiKeyIsGiven()
        {
             securityContext.ApiKey = "Some Api Key";
        }
        
        [Then(@"the response HTTP code should be (.*)")]
        public void ThenTheStatusCodeShouldBe(int statusCode)
        {
             Assert.AreEqual (statusCode, (int)responseContext.Response.StatusCode);
        }
    }
    
    public class MyFeatureSteps
    {
         private SecurityContext securityContext;
         private ResponseContext responseContext;
    
         public MyFeatureSteps(SecurityContext securityContext,ResponseContext responseContext)
        {
             this.securityContext = securityContext;
             this.responseContext = responseContext;
        }
    
        ///Then in your feature steps you can use the Api key you set and set the response
    }
