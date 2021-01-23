    public class IpControlAttribute : ActionFilterAttribute {
        private const string LOCALIP = "";
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            var request = filterContext.RequestContext.HttpContext.Request;
            string ip1 = request.UserHostAddress;
            string shortLocalIP;
            if (ip1 != null && ip1.Contains(".")) {
                string[] ipValues = ip1.Split('.');
                shortLocalIP = ipValues[0] + "." + ipValues[1];
            } else {
                shortLocalIP = "192.168";
            }
            //var ip2 = request.ServerVariables["LOCAL_ADDR"];
            //var ip3 = request.ServerVariables["SERVER_ADDR"];
            if (shortLocalIP != LOCALIP) {
                if ("/Login/User".Equals(request.RawUrl, StringComparison.InvariantCultureIgnoreCase)) {
                    return;
                }
                filterContext.Result = new RedirectResult("/Account/Login");
            }
        }
    }
