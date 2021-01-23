    public class MyCustomHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBegin;
        }
        private void OnBegin(object sender, EventArgs e)
        {
            var app = (HttpApplication) sender;
            var context = app.Context;
            if (context.Request.HttpMethod == "POST")
            {
                string soapActionHeader = context.Request.Headers["SOAPAction"];
                byte[] buffer = new byte[context.Request.InputStream.Length];
                context.Request.InputStream.Read(buffer, 0, buffer.Length);
                context.Request.InputStream.Position = 0;
                string rawRequest = Encoding.ASCII.GetString(buffer);
                var soapEnvelope = new XmlDocument();
                soapEnvelope.LoadXml(rawRequest);
                string response = DoSomeMagic(soapActionHeader, soapEnvelope);
                context.Response.ContentType = "text/xml";
                context.Response.ContentEncoding = Encoding.UTF8;
                context.Response.Write(response);
            }
            else
            {
                //do something else
                //returning a WSDL file for an appropriate GET request is nice
            }
            context.Response.Flush();
            context.Response.SuppressContent = true;
            context.ApplicationInstance.CompleteRequest();
        }
        private string DoSomeMagic(string soapActionHeader, XmlDocument soapEnvelope)
        {
            //magic happens here
        }
    
        public void Dispose()
        {
 	       //nothing happens here
 	       //a Dispose() implementation is required by the IHttpModule interface
        }
    }
