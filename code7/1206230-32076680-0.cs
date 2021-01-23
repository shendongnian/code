        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _max = Helpers.GetSource(Request.QueryString["source"]);
            if (_max == null)
            {
                filterContext.Result =
                    Content("Please check your request URL format, there is no source defined for your input");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
