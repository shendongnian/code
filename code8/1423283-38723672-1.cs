    public class BaseController : Controller
    {
        PIAEntities db = new PIAEntities();
    
        protected IEnumerable<Actualite> sliders { get; private set; }
    
        protected IEnumerable<Paternaire> partenaires { get; private set; }
    
        public BaseController()
        {
            this.sliders = db.Actualite.Where(a => a.Afficher).OrderByDescending(a => a.Date_publication);
            this.partenaires = db.Partenaire.Where(p => p.Afficher);
        }
    }
