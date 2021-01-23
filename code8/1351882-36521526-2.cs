    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Web;
    using System.Text;
    using System.Web;
    namespace SampleWCFConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                FileServer.Start();
            }
        }
        [ServiceContract]
        public class FileServer
        {
            static WebServiceHost _Host;
            public static void Start()
            {
                _Host = new WebServiceHost(typeof(FileServer), new Uri("http://0.0.0.0:8088/FileServer"));
                _Host.Open();
                Console.ReadLine();
            }
            [OperationContract, WebGet(UriTemplate = "*")]
            public Message Get()
            {
                var ctx = WebOperationContext.Current;
                var fileName = Path.Combine("Files", String.Join("/", WebOperationContext.Current.IncomingRequest.UriTemplateMatch.RelativePathSegments));
            
                var fInfo = new FileInfo(fileName);
            
                var eTag = ctx.IncomingRequest.Headers[HttpRequestHeader.IfNoneMatch];
                if (!string.IsNullOrEmpty(eTag))
                {
                    if (GetETag(fInfo) == eTag)
                    {
                        ctx.OutgoingResponse.StatusCode = HttpStatusCode.NotModified;
                        return ctx.CreateTextResponse("");
                    }
                }
                if (fInfo.Exists == false) return ReturnError(ctx, HttpStatusCode.NotFound);
                return ReturnFile(ctx, fInfo);
            }
            static string GetETag(FileInfo fInfo)
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(fInfo.Name).Concat(BitConverter.GetBytes(fInfo.LastWriteTime.Ticks)).ToArray());
            }
            public static Message ReturnError(WebOperationContext ctx, HttpStatusCode statusCode)
            {
                ctx.OutgoingResponse.StatusCode = statusCode;
                return ctx.CreateTextResponse(statusCode.ToString(), "text/html");
            }
            static Message ReturnFile(WebOperationContext ctx, FileInfo fInfo, HttpStatusCode statusCode = HttpStatusCode.OK)
            {
                ctx.OutgoingResponse.StatusCode = statusCode;
                ctx.OutgoingResponse.ETag = GetETag(fInfo);
            
                return ctx.CreateStreamResponse(File.OpenRead(fInfo.FullName), MimeMapping.GetMimeMapping(fInfo.Name));
            }
        }
    }
