    return (new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(
                            new
                            {
                                controller = "Home",
                                action = "myAction",
                                area = "myArea"
                            })));
