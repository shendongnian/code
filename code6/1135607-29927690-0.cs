        public class AuthorizeMsgModule : IHttpModule
        {            
            public void Init(HttpApplication context)
            {                
                context.EndRequest += OnApplicationEndRequest;
            }
            
            // If the request was unauthorized, add the WWW-Authenticate header 
            // to the response.
            private static void OnApplicationEndRequest(object sender, EventArgs e)
            {
                var response = HttpContext.Current.Response;
                if (response.StatusCode == 401)
                {
                    response.ClearContent();
                    response.Write("{\"message\": \"... insert error message here ...\",\"details\": null}");                    
                }
            }
            public void Dispose()
            {
            }
        }
