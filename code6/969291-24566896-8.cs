      public class TransaccionesAreaRegistration : AreaRegistration
      {
        public override string AreaName
        {
          get{
              return “Transacciones”; 
          }
        }
      public override void RegisterArea(AreaRegistrationContext context){
        context.MapRoute(
            “Transacciones_default”,
            “Transacciones/{controller}/{action}/{id}”,
            new { action = ”Index”, id = UrlParameter.Optional },
            new string[] { "MyApp.Transacciones.Controllers" }  // specify the new namespace
           );
        }
    }
        ------------------------------OR Try This--------------------------------
     public class RouteConfig
     {
       public static void RegisterRoute(RouteCollection routes)
       {
         routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
         AreaRegistration.RegisterAllAreas();
         route.MapRoute(
         name: "Default",
         url: "{controller}/{action}/{id}",
         defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional }
          );
        }
      }
