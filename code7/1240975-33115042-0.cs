    public class FormsController : SurfaceController
    {
        [ChildActionOnly]
        public ActionResult ContactUs()
        {
            HtmlHelper.UnobtrusiveJavaScriptEnabled = true;
            HtmlHelper.ClientValidationEnabled = true;
            ContactForm model = null;
            if (TempData.ContainsKey("ContactForm"))
            {
                model = TempData["ContactForm"] as ContactForm;
            }
            if (model == null)
            {
                model = new ContactForm { Page = CurrentPage };
            }
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult HandleContactUs(ContactForm model)
        {
            if (ModelState.IsValid)
            {
                string errorMsg = string.Empty;
                TempData["ContactFormSuccess"] = model.SendMail(Umbraco, out errorMsg);
                TempData["ContactFormErrorMessage"] = errorMsg;
            }
            else
            {
                TempData["ContactFormSuccess"] = false;
            }
            TempData["ContactForm"] = model;
            if (!Request.IsAjaxRequest())
                RedirectToCurrentUmbracoUrl();
            return PartialView(model);
        }
    }
