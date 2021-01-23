    using Sitecore;
    using Sitecore.Pipelines.HttpRequest;
     
    namespace InSitecore.Sample {
        public class CustomItemResolver : HttpRequestProcessor {
     
            public override void Process( HttpRequestArgs args ) {
                if( Context.Item == null ) {
                    return;
                }
     
                // Implement custom custom item lookup logic here
            }
        }
    }
