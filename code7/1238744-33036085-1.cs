    using System;
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;
    namespace Resources.API
    {
        public class ProxyHandler : DelegatingHandler
        {
            private const int ReadStreamBufferSize = 1024 * 1024;
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var routes = new[]{
                    "/api/videos",
                    "/api/documents"
                };
                // check whether we need to proxy this request
                var passThrough = !routes.Any(route => request.RequestUri.LocalPath.StartsWith(route));
                if (passThrough)
                    return await base.SendAsync(request, cancellationToken);
                // got a hit forward the request to the proxy Web API
                //return GetResponseFromProxy(request);
                //Nicer method using HttpClient - but it doesn't work on IIS!
                return await ForwardRequest(request, cancellationToken);
            }
            private static async Task<HttpResponseMessage> ForwardRequest(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                //Clone the request and forward to the internal proxy site
                var proxyUrl = ConfigurationManager.AppSettings["ProxyUrl"];
                var baseUri = new UriBuilder(proxyUrl);
                //clone the requestUri and point it at the proxy site
                var forwardedUri = new UriBuilder(request.RequestUri)
                {
                    Scheme = baseUri.Scheme,
                    Host = baseUri.Host,
                    Port = baseUri.Port
                };
                var forwardRequest = new HttpRequestMessage(request.Method, forwardedUri.Uri);
                if (request.Method == HttpMethod.Post || request.Method == HttpMethod.Put)
                {
                    var stream = new MemoryStream();
                    await request.Content.CopyToAsync(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    forwardRequest.Content = new StreamContent(stream);
                    //copy the content headers
                    foreach (var header in request.Content.Headers)
                    {
                        forwardRequest.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    }
                };
                forwardRequest.Version = request.Version;
                foreach (var prop in request.Properties)
                {
                    forwardRequest.Properties.Add(prop);
                }
                foreach (var header in request.Headers)
                {
                    forwardRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
                // Don't forget to change the Host header to refer to the proxy
                forwardRequest.Headers.Host = forwardRequest.RequestUri.Host;
                //Add the relevant X-Forwarded headers
                var xForwardedHost = request.Headers.Host;
                forwardRequest.Headers.Add("X-Forwarded-Host", xForwardedHost);
                var xForwardedFor = HttpContext.Current.Request.UserHostAddress;
                forwardRequest.Headers.Add("X-Forwarded-For", xForwardedFor);
                var client = new HttpClient(new HttpClientHandler(), disposeHandler: false);
                try
                {
                    return await client.SendAsync(forwardRequest, HttpCompletionOption.ResponseHeadersRead,
                        cancellationToken);
                }
                catch (Exception e)
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        Content =
                            new ObjectContent<HttpError>(new HttpError(e, includeErrorDetail: true),
                                new JsonMediaTypeFormatter())
                    };
                }
            }
        }
    }
