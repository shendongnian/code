    public class CustomerController : Controller
        {
            IDal dal = null;
            public CustomerController(IDal _dal
                                    ,IDal _dal1)
            {
                dal = _dal;
                // DI of MVC core
                // inversion of control
            }
    }
