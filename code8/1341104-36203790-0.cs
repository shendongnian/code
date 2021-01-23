    public class TransactionalAttribute : ActionFilterAttribute
    {
        private IUnitOfWork _unitOfWork;
     
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Controller.ViewData.ModelState.IsValid && filterContext.HttpContext.Error == null)
                _unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();
     
            base.OnActionExecuting(filterContext);
        }
     
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Controller.ViewData.ModelState.IsValid && filterContext.HttpContext.Error == null && _unitOfWork != null)
                _unitOfWork.SaveChanges();
     
            base.OnActionExecuted(filterContext);
        }
    }
