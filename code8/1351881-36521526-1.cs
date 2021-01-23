    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Web;
    using System.Text;
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
                return ctx.CreateStreamResponse(File.OpenRead(fInfo.FullName), MIME[fInfo.Extension.ToLowerInvariant()]);
            }
            static Dictionary<string, string> MIME = new Dictionary<string, string>(){
                {".htm","text/html"},
                {".html","text/html"},
                {".txt","text/html"},
                {".js","application/x-javascript"},
                {".swf","application/x-shockwave-flash"},
                {".m3u", "audio/x-mpegurl"},
                {".m3u8","application/x-mpegURL"},
                {".ts","video/vnd.dlna.mpeg-tts"},
                {".png","image/png"},
                {".jpg","image/jpeg"},
                {".jpeg","image/jpeg"},
                {".gif","image/gif"},
                {".css","text/css"},
                {".woff","application/font-woff"},
                {".woff2","application/font-woff2"},
                {".eot","application/vnd.ms-fontobject"},
                {".otf","font/opentype"},
                {".ttf", "application/octet-stream"},
                {".svg","image/svg+xml"},
                {".pdf","application/pdf"},
                {".map", "application/json" }
            };
        }
    }
