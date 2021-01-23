    protected class AddRenewOnAauthorizedResult : IHttpActionResult {
    
        public const string RenewalPropertyKey = "ETicket.RenewalKey";
        public AddRenewOnAauthorizedResult(HttpRequestMessage request, IHttpActionResult innerResult) {
            this.Request = request;
            this.InnerResult = innerResult;
        }
        public HttpRequestMessage Request { get; set; }
        public IHttpActionResult InnerResult { get; set; }
        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken) {
            HttpResponseMessage response = await this.InnerResult.ExecuteAsync(cancellationToken);
                    
            if (Request.Properties.ContainsKey(RenewalPropertyKey)) Request.response.Headers.Add("X-ETicket-Renew", Request.Properties(RenewalPropertyKey));
            Return response;
    }
