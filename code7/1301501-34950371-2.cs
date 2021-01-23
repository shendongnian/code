    public class RebindingHandler : DelegatingHandler
    {
		private BindIPEndPoint bindHandler;
        public RebindingHandler(IEnumerable<IPAddress> adapterAddresses, HttpMessageHandler innerHandler = null)
            : base(innerHandler ?? new WebRequestHandler())
        {
			var addresses=adapterAddresses.ToList();
			if(!addresses.Any())
			{
				throw new ArgumentException();
			}
			var idx=0;
			bindHandler= (servicePoint, remoteEndPoint, retryCount) => {
				var index = (idx++)%addresses.Count;
				IPAddress adapterIpAddress = addresses[index];
				return new IPEndPoint(adapterIpAddress, 0);
			};
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
			var sp = ServicePointManager.FindServicePoint(request.RequestUri);
			sp.BindIPEndPointDelegate = bindHandler;
			var httpResponseMessage = await base.SendAsync(request, cancellationToken);
            return httpResponseMessage;
        }
    }
