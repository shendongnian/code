    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    namespace WebApplication1.Controllers
    {
        public class HomeController : Controller
        {
            const string SESSION_SAVED_MODEL = "savedModel";
            [HttpGet]
            public ActionResult Index()
            {
                Session[SESSION_SAVED_MODEL] = new List<RessursBehov> { new RessursBehov() };
                return View(Session[SESSION_SAVED_MODEL]);
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Index(IList<RessursBehov> model)
            {
                 if (Request.Params["Ekstra_Ressurs"] != null)
                {
                    model.Add(new RessursBehov());
                    Session[SESSION_SAVED_MODEL] = model;
                }
                return View(model);
            }
        }
        public class RessursBehov
        {
            [Required, Display(Name = "Antall timer")]
            public int? Antall_Timer { get; set; }
            [Required, Display(Name = "Antall uker")]
            public int? Antall_Uker { get; set; }
        }
    }
