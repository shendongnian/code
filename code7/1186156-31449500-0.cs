    namespace YourProject.Controllers
    {
        public class HomeController : Controller
        {
      
            #region Actions
            public ActionResult Index()
            {
                try
                {
                  NameofYourdll.ClassName tVar = new NameofYourdll.ClassName();
                 tVar.Create();
                    return View();
                }
                catch (Exception ex)
                {
                   throw;
                }
            }
            #endregion
    }}
