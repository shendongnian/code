    public class MyBaseController : Controller
    {
        public virtual ActionResult Help()
        {
            // Do default behavior stuff, if appropriate
        }
        // If you don't have any "default" behavior, you could make the method abstract:
        // public abstract ActionResult Help();
    }
    public class PeopleController : MyBaseController
    {
         public override ActionResult Help()
         {
             // Do stuff.
         }
    }
