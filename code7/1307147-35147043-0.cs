    using System;
    using System.Net.Http.Headers;
    using System.Web.Http;
    using Umbraco.Web;
    namespace MyNamespace
    {
        public class CustomGlobal : UmbracoApplication
        {
            private void application_PreRequestHandlerExecute(object sender, EventArgs e)
            {
                var formatters = GlobalConfiguration.Configuration.Formatters;
                formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            }
        }
    }
