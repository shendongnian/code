    public class ErrorTestController : Controller
    {
		public ActionResult ReturnSpecifiedCode(int httpStatusCode)
		{	
            return new HttpStatusCodeResult(httpStatusCode)
        }
        public ActionResult ThrowApplicationError()
        {
            Throw new Exception("Boo!");
        }
    }
