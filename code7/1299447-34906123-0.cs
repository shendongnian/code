    public class HeaderViewComponent : ViewComponent
    {
      private string viewName;
      private readonly IStringLocalizer _localizer;
      public HeaderViewComponent(IStringLocalizerFactory localizedFactory)
      {
         _localizer = localizedFactory.Create("name.of.your.resource.file", "Namespace");
      } 
      public IViewComponentResult Invoke()
      {
        [...]
        ViewBag.StringLocalizer = _localizer;
        return View("name", model);
      }
    }
