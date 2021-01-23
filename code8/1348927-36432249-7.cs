    using System;
    using System.IO;
    using System.Net;
    using Microsoft.Azure.WebJobs;
    public static async Task<HttpResponseMessage> 
           Run(HttpRequestMessage req, Binder binder, TraceWriter log)
    {
        log.Verbose($"C# HTTP function processed RequestUri={req.RequestUri}");
        using (var writer = await binder.BindAsync<TextWriter>(
                      new BlobAttribute("test-output/result")))
        {
            writer.Write("Hello World!!");
        }
            
        return new HttpResponseMessage(HttpStatusCode.OK);
    }
