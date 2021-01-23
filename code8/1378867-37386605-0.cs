    public class MockRestClient : RestClient
    {
        public TestServer TestServer { get; set; }
        public MockRestClient(TestServer testServer)
        {
            TestServer = testServer;
        }
        public override IRestResponse Execute(IRestRequest request)
        {
            // TODO: Currently the test server is only doing GET requests via RestSharp
            HttpResponseMessage response = null;
            Parameter body = request.Parameters.FirstOrDefault(p => p.Type == ParameterType.RequestBody);
            HttpContent content;
            
            if (body != null)
            {
                object val = body.Value;
                byte[] requestBodyBytes;
                string requestBody;
                
                if (val is byte[])
                {
                    requestBodyBytes = (byte[]) val;
                    content = new ByteArrayContent(requestBodyBytes);
                }
                else
                {
                    requestBody = Convert.ToString(body.Value);
                    content = new StringContent(requestBody);
                }
            }
            else 
                content = new StringContent("");
            string urladd = "";
            IEnumerable<string> @params = from p in request.Parameters
                where p.Type == ParameterType.GetOrPost && p.Value != null
                select p.Name + "=" + p.Value;
            if(!@params.IsNullOrEmpty())
                urladd = "?" + String.Join("&", @params);
            IEnumerable<HttpHeader> headers = from p in request.Parameters
                                              where p.Type == ParameterType.HttpHeader
                                              select new HttpHeader
                                              {
                                                  Name = p.Name,
                                                  Value = Convert.ToString(p.Value)
                                              };
            foreach (HttpHeader header in headers)
            {
                content.Headers.Add(header.Name, header.Value);
            }
            content.Headers.ContentType.MediaType = "application/json";
            switch (request.Method)
            {
                case Method.GET:
                    response = TestServer.HttpClient.GetAsync(request.Resource + urladd).Result;
                    break;
                case Method.DELETE:
                    response = TestServer.HttpClient.DeleteAsync(request.Resource + urladd).Result;
                    break;
                case Method.POST:
                    response = TestServer.HttpClient.PostAsync(request.Resource + urladd, content).Result;
                    break;
                case Method.PUT:
                    response = TestServer.HttpClient.PutAsync(request.Resource + urladd, content).Result;
                    break;
                default:
                    return null;
            }
            var restResponse = ConvertToRestResponse(request, response);
            return restResponse;
        }
        private static RestResponse ConvertToRestResponse(IRestRequest request, HttpResponseMessage httpResponse)
        {
            RestResponse restResponse1 = new RestResponse();
            restResponse1.Content = httpResponse.Content.ReadAsStringAsync().Result;
            restResponse1.ContentEncoding = httpResponse.Content.Headers.ContentEncoding.FirstOrDefault();
            restResponse1.ContentLength = (long)httpResponse.Content.Headers.ContentLength;
            restResponse1.ContentType = httpResponse.Content.Headers.ContentType.ToString();
            if (httpResponse.IsSuccessStatusCode == false)
            {
                restResponse1.ErrorException = new HttpRequestException();
                restResponse1.ErrorMessage = httpResponse.Content.ToString();
                restResponse1.ResponseStatus = ResponseStatus.Error;
            }
            restResponse1.RawBytes = httpResponse.Content.ReadAsByteArrayAsync().Result;
            restResponse1.ResponseUri = httpResponse.Headers.Location;
            restResponse1.Server = "http://localhost";
            restResponse1.StatusCode = httpResponse.StatusCode;
            restResponse1.StatusDescription = httpResponse.ReasonPhrase;
            restResponse1.Request = request;
            RestResponse restResponse2 = restResponse1;
            foreach (var httpHeader in httpResponse.Headers)
                restResponse2.Headers.Add(new Parameter()
                {
                    Name = httpHeader.Key,
                    Value = (object)httpHeader.Value,
                    Type = ParameterType.HttpHeader
                });
            //foreach (var httpCookie in httpResponse.Content.)
            //    restResponse2.Cookies.Add(new RestResponseCookie()
            //    {
            //        Comment = httpCookie.Comment,
            //        CommentUri = httpCookie.CommentUri,
            //        Discard = httpCookie.Discard,
            //        Domain = httpCookie.Domain,
            //        Expired = httpCookie.Expired,
            //        Expires = httpCookie.Expires,
            //        HttpOnly = httpCookie.HttpOnly,
            //        Name = httpCookie.Name,
            //        Path = httpCookie.Path,
            //        Port = httpCookie.Port,
            //        Secure = httpCookie.Secure,
            //        TimeStamp = httpCookie.TimeStamp,
            //        Value = httpCookie.Value,
            //        Version = httpCookie.Version
            //    });
            return restResponse2;
        }
