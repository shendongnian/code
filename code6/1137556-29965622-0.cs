    public abstract class ControllerBase : Controller
    {
        protected ActionResult ViewModelResult(ViewModel viewModel)
        {
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }
    }
    public class ValuesController : ControllerBase
    {
        public ActionResult Index()
        {
            var vm = ...;
            return ViewModelResult(vm);
        }
    }
