    public class BaseController<T> : Controller
        where T : class, new
    {
        public ActionResult Process(T modelInstance)
        {
            return ProcessModel(modelInstance);
        }
       ...
    }
