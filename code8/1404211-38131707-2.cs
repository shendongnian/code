    public interface IErrorViewModel
    {
        IEnumerable<ErrorViewModel> Errors { get; set; }
    }
    public MyViewModel : IErrorViewModel
    {
        public string Name { get; set; }
        public IEnumerable<ErrorViewModel> Errors { get; set; }
    }
    public class SetErrorModelAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            IErrorViewModel model = filterContext.Controller.ViewData.Model as IErrorViewModel;
            model.Errors = filterContext.Controller.TempData["Errors"] as IEnumerable<ErrorViewModel>;
        }
    }
