    public class FacebookBackChannelHandler : HttpClientHandler
    {
        protected override async System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (!request.RequestUri.AbsolutePath.Contains("/oauth"))
            {
                request.RequestUri = new Uri(request.RequestUri.AbsoluteUri.Replace("?access_token", "&access_token"));
            }
            var result = await base.SendAsync(request, cancellationToken);
            if (!request.RequestUri.AbsolutePath.Contains("/oauth"))
            {
                return result;
            }
      
            var content = await result.Content.ReadAsStringAsync();
            var facebookOauthResponse = JsonConvert.DeserializeObject<FacebookOauthResponse>(content);
            var outgoingQueryString = HttpUtility.ParseQueryString(string.Empty);
            outgoingQueryString.Add("access_token", facebookOauthResponse.access_token);
            outgoingQueryString.Add("expires_in", facebookOauthResponse.expires_in + string.Empty);
            outgoingQueryString.Add("token_type", facebookOauthResponse.token_type);
            var postdata = outgoingQueryString.ToString();
            var modifiedResult = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(postdata)
            };
            return modifiedResult;
        }
    }
    public class FacebookOauthResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
