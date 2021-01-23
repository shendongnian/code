    public class MyRoute : Route
    {
        public MyRoute() : base(
            "Home/Lead",
            new RouteValueDictionary(new
            {
                controller = "Home",
                action = "Lead",
            }),
            new MvcRouteHandler()
        )
        {
        }
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var rd = base.GetRouteData(httpContext);
            if (rd == null)
            {
                return null;
            }
            var leadId = httpContext.Request.QueryString["leadid"];
            if (!string.IsNullOrEmpty(leadId))
            {
                rd.Values["id"] = leadId;
            }
            return rd;
        }
    }
