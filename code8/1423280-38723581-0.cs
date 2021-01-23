	public class BaseController : Controller
	{
		PIAEntities db = new PIAEntities();
		IQueryable<Actualite> sliders;
		IQueryable<Paternaire> partenaires;
		
		public BaseController()
		{
			sliders = db.Actualite.Where(a => a.Afficher).OrderByDescending(a => a.Date_publication);
			partenaires = db.Partenaire.Where(p => p.Afficher);
		}
	}
