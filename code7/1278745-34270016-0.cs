    public class HomeCustomDataBinder : DefaultModelBinder
    {
        public override object BindModel(
            ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            // Various things.
        }
    }
    public ActionResult Index(
        [ModelBinder(typeof(HomeCustomBinder))] HomePageModels home)
    {
        // Various things.
    }
