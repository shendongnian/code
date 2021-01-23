    public class JsonProtector : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(
                    HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            // Manipulate response here.
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                responseData = ")]}',\n" + responseData;
                var repo = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(responseData));
                response.Content = new StreamContent(repo);
            }
            return response;
        }
    }
