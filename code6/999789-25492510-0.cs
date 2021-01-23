    public ActionResult ChildAction(ChildClass model)
    {
        return PartialView("Partials/BaseClassView", model);
    }
    public class ChildClass : BaseClass
    {
    
    }
    public class BaseClass : IBaseClass
    {
    
    }
    public interface IBaseClass
    {
    
    }
