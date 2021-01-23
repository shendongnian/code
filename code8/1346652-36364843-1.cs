    public class ContextParameterTest : WebTest
    {
         public override IEnumerator<WebTestRequest> GetRequestEnumerator()
         {
              var serviceUrl = this.Context[ContextParamKey].ToString();
              WebTestRequest webTestRequest = new WebTestRequest(serviceUrl);
              
              ... build your request
    
              request.PostRequest += request_PostRequest;
              yield return request;
              request = null;
         }
    }    
