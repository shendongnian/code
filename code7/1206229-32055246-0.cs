    public abstract class MyBaseController : Controller
    { 
        protected void SomeCommonMethod()
        {
             ....
        }
    }
    public class HomeController : MyBaseController
    {
        public void Index()
        {
             SomeCommonMethod();
        }
    }
