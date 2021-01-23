    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Threading;
    using System.Threading.Tasks;
    using Windows.Foundation;
    using Windows.Web.Http;
    using Windows.Web.Http.Filters;
    
    namespace Project.UnitTesting
    {
        public class FakeResponseFilter : IHttpFilter
        {
            private readonly Dictionary<Uri, HttpResponseMessage> _fakeResponses = new Dictionary<Uri, HttpResponseMessage>();
    
            public void AddFakeResponse(Uri uri, HttpResponseMessage responseMessage)
            {
                _fakeResponses.Add(uri, responseMessage);
            }
    
            public void Dispose()
            {
                // Nothing to dispose
            }
    
            public IAsyncOperationWithProgress<HttpResponseMessage, HttpProgress> SendRequestAsync(HttpRequestMessage request)
            {
                if (_fakeResponses.ContainsKey(request.RequestUri))
                {
                    var fakeResponse = _fakeResponses[request.RequestUri];
                    return DownloadStringAsync(fakeResponse);
                }
    
    			// Alternatively, you might want to throw here if a request comes 
    			// in that is not in the _fakeResponses dictionary.
                return DownloadStringAsync(new HttpResponseMessage(HttpStatusCode.NotFound) { RequestMessage = request });
            }
    
            private IAsyncOperationWithProgress<HttpResponseMessage, HttpProgress> DownloadStringAsync(HttpResponseMessage message)
            {
                return AsyncInfo.Run(delegate (CancellationToken cancellationToken, IProgress<HttpProgress> progress)
                {
                    progress.Report(new HttpProgress());
    				
                    try
                    {
                        return Task.FromResult(message);
                    }
                    finally
                    {
                        progress.Report(new HttpProgress());
                    }
    				
                });
            }
        }
    }
