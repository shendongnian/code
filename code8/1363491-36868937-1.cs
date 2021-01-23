    public class ErrorTestController : Controller
    {
		public ActionResult ThrowHttpException(int httpStatusCode)
		{	
            throw new HttpException(httpStatusCode, "Error!");
        }
        public ActionResult ThrowApplicationError()
        {
            Throw new Exception("Boo!");
        }
    }
