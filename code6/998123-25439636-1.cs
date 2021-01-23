    public class BaseController<T> : Controller
        where T : class, new
    {
        public ActionResult ActionWithHook(T model)
        {
            DoSomeWork(model);
            return View();
        }
        // By default this does nothing, but can be overridden to do something
        internal virtual void DoSomeWork(T model)
        {
        }
    }
