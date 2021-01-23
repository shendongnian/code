    public class BaseController : Controller
    {
        protected List<Actualite> Actualities {set;get;}
        PIAEntities db = new PIAEntities();
    
        public BaseController()
        {
            this.Actualities  = db.Actualite.Where(a => a.Afficher)
                               .OrderByDescending(a => a.Date_publication).ToList();            
        }
    }
