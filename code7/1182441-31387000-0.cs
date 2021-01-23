     public static object GetSelectedModelId(string ControllerName)
            {
                //var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;
                string controller = (string)HttpContext.Current.Session["controller"];
                object mid = null;
    
    
                if (controller != null && controller.Equals(ControllerName, StringComparison.OrdinalIgnoreCase)) 
                 mid =   HttpContext.Current.Session["SelectedModelId"];            
                HttpContext.Current.Session.Remove("SelectedModelId");
                HttpContext.Current.Session.Remove("controller");
    
                return mid;
            }
    
            public static void SetSelectedModelId(string ControllerName, object ModelId)
            {
                HttpContext.Current.Session["controller"] = ControllerName;
                HttpContext.Current.Session["SelectedModelId"] = ModelId;
            }
