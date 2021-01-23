    private async Task<HttpUtilResponse> DoRequest(List<RequestResponseHeader> headers, HttpMethod method, string url, string requestData) {
         HttpUtilResponse response = new HttpUtilResponse();
         string responseData = string.Empty;
         using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient()) {          
            using (HttpRequestMessage request = new HttpRequestMessage(method, url)) {
               if (headers != null) {
                  headers.ForEach(h => request.Headers.Add(h.Name, h.Value));
               }               
               if (!string.IsNullOrEmpty(requestData)) {
                  if (AppConfig.LogRequestContent) {
                     LOG.Debug(requestData);
                  }
                  request.Content = new StringContent(requestData, Encoding.UTF8, JSON_CONTENT);                  
               }
               using (HttpResponseMessage msg = await client.SendAsync(request, CancelToken.Token)) {
                  response.StatusCode = msg.StatusCode;
                  response.ReasonPhrase = msg.ReasonPhrase;
                  using (HttpContent content = msg.Content) {
                     response.ResponseText = await content.ReadAsStringAsync();
                  }
               }
            }
         }
         return response;
      }  
