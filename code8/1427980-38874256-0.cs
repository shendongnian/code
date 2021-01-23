    public class TrackingActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionId = filterContext.HttpContext.Session.SessionID;
            Debug.WriteLine("Printing session Id: " + sessionId);
            var ip = filterContext.HttpContext.Request.UserHostAddress;
            Debug.WriteLine("Printing ip: " + ip);
            var headers = filterContext.RequestContext.HttpContext.Request.Headers;
            foreach(var header in headers) {
                Debug.WriteLine("Printing header: " + header);
            }
            var parms = filterContext.HttpContext.Request.Params;
            foreach (var key in parms.AllKeys)
            {
                Debug.WriteLine("Printing parameter: " + key + " - " + parms[key]);
            }
            var routeDataKeys = filterContext.RouteData.Values.Keys;
            foreach(var key in routeDataKeys)
            {
                Debug.WriteLine("Printing route data value: " + key + " - " + filterContext.RouteData.Values[key]);
            }
            //Stolen with love from http://stackoverflow.com/questions/12938621/how-can-i-log-all-query-parameters-in-an-action-filter
            var stream = filterContext.HttpContext.Request.InputStream;
            var data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            Debug.WriteLine(Encoding.UTF8.GetString(data));
        }
    }
