    public class PeopleController : MyBaseController // if you're using a base class
    {
        public override ActionResult Help()
        {
            return ViewResult("People");
        }
    }
