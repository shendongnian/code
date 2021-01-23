    using System;
    using System.IO;
    using System.Net;
    using Microsoft.Azure.WebJobs;
    public static HttpResponseMessage Run(HttpRequestMessage req,
                                          IBinder binder, TraceWriter log)
    {
        log.Verbose($"C# HTTP function processed RequestUri={req.RequestUri}");
        using (var writer = binder.Bind<TextWriter>(
                      new BlobAttribute("test-output/result")))
        {
            writer.Write("Hello World!!");
        }
            
        return new HttpResponseMessage(HttpStatusCode.OK);
    }
