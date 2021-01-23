    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class SetTenantActionAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var baseController = filterContext.Controller as BaseController;
            if (baseController == null) return;
            var model = filterContext.Controller.ViewData.Model as BaseViewModel;
            if (model == null) return;
            model.TenantId = baseController.TenantId;
        }
    }
