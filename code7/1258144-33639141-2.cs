    //PL Controller that does something cool
    public class BaseService : Controller
    {
       
        public ActionResult DoSomething(int value)
        {
            using(IUnitOfWork scope = new UnitOfWork())
            {
                ISomeService theService = new SomeService(scope);
                theService.SomeMethod(value);
            }
            ...con
        }
       
    }
