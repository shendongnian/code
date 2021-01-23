    public class MyCustomBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
                                ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;
            string day = request.Form.Get("DobDay");
            string month = request.Form.Get("DobMonth");
            string year = request.Form.Get("DobYear");
            //etc..
            return new Applicant
            {
                BirthDate = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day))
                //etc..
            };
        }
    }
    [HttpPost]
    public ActionResult Save([ModelBinder(typeof(MyCustomBinder))] Applicant applicant)
    {
        return View();
    }
