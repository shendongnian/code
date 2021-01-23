        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var res = filterContext.Result as ViewResult;
            if (res != null)
                res.MasterName = "~/Views/Shared/_FacbookCanvasLayout.cshtml";
        }
