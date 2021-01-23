    public class MenusController {
      [ChildActionOnly]
      public ActionResult MainMenu() {
        var menu = GetMenuFromSomewhere();
       return PartialView(menu);
      }
    }
