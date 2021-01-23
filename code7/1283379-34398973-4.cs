    protected override ViewResult View(string viewName, string masterName, object model)
            {
                var layout = RouteData.Values["layout"].ToString();
    
                switch (layout)
                {
                    case "default":
                        return base.View(viewName, "_layout", model);
                    case "test":
                        return base.View(viewName, "_layout2", model);
                }
    
                return base.View(viewName, masterName, model);
            }
