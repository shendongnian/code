    namespace MesaServicio.Areas.Admin.Controllers
    {
        public class AdminController : Controller
        {
            private ApplicationDbContext db = new ApplicationDbContext();
    
            // GET: Admin/Admin
            public ActionResult Prueba()
            {
                return View(db.Corps.ToList());
            }
        }
    }
