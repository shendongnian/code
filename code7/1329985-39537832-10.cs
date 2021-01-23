    public class BaseController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string[] cultures = { "es-CL", "es-GT", "en-US" };
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultures[1]);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            return base.BeginExecuteCore(callback, state);
        }
    }
