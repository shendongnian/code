    public class MyControllerBase : Controller {
        public Task<ActionResult> GetView() {
            yourCommonMethod();
            return View();
        }
        public Task<ActionResult> GetView(string viewName) {
            yourCommonMethod();
            return View(viewName);
        }
        public Task<ActionResult> GetView(object model) {
            yourCommonMethod();
            return View(model);
        }
        public Task<ActionResult> GetView(string viewName, object model) {
            yourCommonMethod();
            return View(viewName, model);
        }
    }
