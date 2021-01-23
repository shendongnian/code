    using System.Web.Http;
    using System.Web.Http.Dispatcher;
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        public override string GetControllerName(HttpRequestMessage request)
        {
            var name =  base.GetControllerName(request);
            if(string.IsNullOrEmpty(name))
            {
                return "MyFeature"; //important not to include "Controller" suffix
            }
            return name;
        }
    }
