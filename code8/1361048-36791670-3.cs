    public class YourController : Controller
    {
        // Note the Task<ActionResult> and async in your controller.
        public async Task<ActionResult> YourControllerMethod()
        {
            var model = await this.quantService.GetIndexViewModel(companyIds, isMore, currentrole);
            return View(model); // Or something like this.
        }
    }
