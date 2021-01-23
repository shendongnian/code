    public class BestuuurController : Controller
    {    
        BestuuurController(PlanToolEntities context)
        {
            db = context;
        }
        PlanToolEntities db;
    }
