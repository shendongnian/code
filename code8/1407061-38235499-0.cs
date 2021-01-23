    public class LanguageModel 
    {
        public List<SelectListItem> LanguageList { get; set; }
        public string LanguageAbbrevation { get; set; }
        
        public static List<SelectListItem> GetList()
        {
            List<SelectListItem> list = new List<SelectListItem>
            {
                new SelectListItem { Text = "English", Value = "en" },
                new SelectListItem { Text = "French", Value = "fr" },
            };
            return list;
        }
    }
    public class HomeController : Controller
    {
        public ActionResult AAIndex()
        {
            LanguageModel securityQuestionModel = new LanguageModel();
            securityQuestionModel.LanguageList = LanguageModel.GetList();
            return View("AAIndex", securityQuestionModel);
        }
        [HttpPost]
        public ActionResult Change(String LanguageAbbrevation)
        {
            if (LanguageAbbrevation != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);
            }
            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = LanguageAbbrevation;
            Response.Cookies.Add(cookie);
            return View("AAIndex");
        }
