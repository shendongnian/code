    public abstract class FrontOfficeControllerBase : Controller {
        protected override void HandleUnknownAction(string actionName) {
            var data = ViewData;
            //Custom code to resolve the view.
            //ViewResult view = this.View<ErrorController>(c => c.NotFound());
            //Manually create view with view Data
            ViewResult view = new ViewResult();
            view.ViewData = new ViewDataDictionary();
            view.ViewData["controller"] = "Error";
            view.ViewData["action"] = "NotFound";
            if (data != null && data.Count > 0) {
                data.ToList().ForEach(view.ViewData.Add);
            }
            Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
            Response.TrySkipIisCustomErrors = true;
            view.ExecuteResult(this.ControllerContext);
        }
    }
