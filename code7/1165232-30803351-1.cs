    public class SomeController
    {
       public ActionResult Index()
       {
           SelectList list = GetRoutingActionList();
           list  = new SelectList(list 
                                  .Where(x => x.Value != "Disapprove")
                                  .ToList(),
                                  "Value",
                                  "Text");
            return View();
       }
    }
