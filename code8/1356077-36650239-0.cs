    public class HomeController : BaseController
    {
        public ActionResult Pages(string mainCategory, string subCategory, string pageName)
        {
            var model = _pageDetailsRepository.GetPageDetails(mainCategory, subCategory, false);
            if (model == null)
            {
                // return View("Error")
                return HttpNotFound();
            }
        }
    }
