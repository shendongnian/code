    namespace Mymodels.Models
    {
        public class myHandler : DelegatingHandler
        {
            protected async override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, CancellationToken cancellationToken)
            {            
                var response = await base.SendAsync(request, cancellationToken);
    
                 if (response.StatusCode != HttpStatusCode.NotFound) //if response is NOT 404
                {
                    //do response work here since response is not 404
                }
                else
                {
                    response.StatusCode = HttpStatusCode.Redirect; //set status code to 302
                    HttpContext.Current.Response.RedirectToRoute("customErrorRequestPage", "Home"); 
    
                }
                return response;
            }
        }
    }
