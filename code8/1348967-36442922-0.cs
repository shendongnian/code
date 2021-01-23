        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext != null)
            {
                //set vlaue in context
                filterContext.RouteData.DataTokens.Add("VariableName", "Value of variable");
                //Log information
                Log("OnActionExecuting", filterContext.RouteData);
            }
        }
