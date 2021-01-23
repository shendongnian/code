            public class ApiGatewayHandler : DelegatingHandler
            { 
               protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
               {
                 var response = await base.SendAsync(request, cancellationToken);
                             
                if (response!=null && response.StatusCode == HttpStatusCode.NotFound)
                {
                    var msg = await response.Content.ReadAsStringAsync();
                    //you can change the response here
                    if (msg != null && msg.Contains("No HTTP resource was found"))
                    {
                        return new HttpResponseMessage
                        {
                            StatusCode = HttpStatusCode.NotFound,
                            Content = new ObjectContent(typeof(object), new { Message = "New Message..No HTTP resource was found that matches the request URI" }, new JsonMediaTypeFormatter())
                        };
                    }
                }
                return response;
             
            return response;
        }
    }
