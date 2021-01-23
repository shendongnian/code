    public class ExampleController : Controller
    {
        public ActionResult Test()
        {
            TestViewModel model = new TestViewModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Foo bar"
            };
            return this.View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Test(TestViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            return this.Content("Success");
        }
    }
