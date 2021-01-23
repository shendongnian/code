    public class BaseController : Controller
    {
       PIAEntities db = new PIAEntities();
       // Fields added
       protected IQueryable<Partenaire> partenaires ;
       protected IQueryable<Actualite> sliders ;
       public BaseController()
       {
           sliders = db.Actualite.Where(a => a.Afficher).OrderByDescending(a => a.Date_publication);
           partenaires = db.Partenaire.Where(p => p.Afficher);
       }
    }
