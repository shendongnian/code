    public class MyController : Controller
    {
         public ActionResult Index()
         {
              UserColorAddEditViewModel Model = new UserColorAddEditViewModel();
              Model.ColourSelectList = Enum.
					GetValues(typeof(Color)).
					Cast<Color>().
					Select(c => new SelectListItem { Text = c.ToString(), Value = ((int)c).ToString()}).ToList();
            return View(Model);
		}
    }
