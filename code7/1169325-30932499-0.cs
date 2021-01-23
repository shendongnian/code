    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                           {
                               { "action", "Index" },
                               { "controller", "Unauthorized" },
                               { "Area", String.Empty }
                           });
