    public class LoadMenu : ActionFilterAttribute
    {
       public override void OnActionExecuted(ActionExecutedContext filterContext)
       {
            var vb = filterContext.Controller.ViewBag;
            var menu = new List<MenuItem>
            {
              new MenuItem(){
                 Text = "Home",
                 Childs = new List<MenuItem>
                {
                    new MenuItem {Text = "About"}
                }
               }
           };
           vb.Menus = menu;
    
         }
    }
