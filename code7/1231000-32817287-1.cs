    public class PassAlongParametersFilter : ActionFilterAttribute
        {
            public string Filter { get; set; }
            public PassAlongParametersFilter()
            {
                Filter = "*";
            }
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                if (filterContext.Result is RedirectToRouteResult)
                {
                    var action = (RedirectToRouteResult)filterContext.Result;
                    var qs = filterContext.RequestContext.HttpContext.Request.QueryString;
                    var regex = StringUtils.WildcardToRegex(Filter);
                    var routeValues = action.RouteValues;
                    qs.AllKeys.Where(e => Regex.IsMatch(e, regex)).ForEach(s => routeValues[s] = qs[s]);
                    filterContext.Result = new RedirectToRouteResult(action.RouteName, routeValues, action.Permanent);
                }
            }
        }
