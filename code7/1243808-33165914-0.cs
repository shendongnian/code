    public class [my]Controller : BaseController
    {
        public ResualtAction [my]Action 
            return Base.Something();
        }
    }
    
    public class BaseController : Controller
    {
        public CustomeReturnAction Something()
        {
            return new CustomeReturnAction();
        }
    }
