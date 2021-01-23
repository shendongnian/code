    public class LoggerMiddleware : OwinMiddleware
    {
        public LoggerMiddleware(OwinMiddleware next): base(next)
        {
        }
        public async override Task Invoke(IOwinContext context)
        {
            //to intercept MVC responses, because they don't go through OWIN
            HttpResponse httpResponse = HttpContext.Current.Response;
            OutputCaptureStream outputCapture = new OutputCaptureStream(httpResponse.Filter);
            httpResponse.Filter = outputCapture;
                        
            IOwinResponse owinResponse = context.Response;
            //buffer the response stream in order to intercept downstream writes
            Stream owinResponseStream = owinResponse.Body;
            owinResponse.Body = new MemoryStream();
            await Next.Invoke(context);
            if (outputCapture.CapturedData.Length == 0) {
                //response is formed by OWIN
                //make sure the response we buffered is flushed to the client
                owinResponse.Body.Position = 0;
                await owinResponse.Body.CopyToAsync(owinResponseStream);
            } else {   
                //response by MVC
                //write captured data to response body as if it was written by OWIN         
                outputCapture.CapturedData.Position = 0;
                outputCapture.CapturedData.CopyTo(owinResponse.Body);
            }
            
            LogResponse(owinResponse);
        }
    }
