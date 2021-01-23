        [TestMethod]
        public void FakeHttpClient()
        {
            using (ShimsContext.Create())
            {
                System.Net.Http.Fakes.ShimHttpClient.AllInstances.GetAsyncString = (httpClient, stringUri) =>
                {
                  //Return a service unavailable response
                  var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
                  var task = Task.FromResult(httpResponseMessage);
                  return task;
                };
        
                //your implementation will use the fake method(s) automatically
                var client = new Connection(_httpClient);
                client.doSomething(); 
            }
        }
