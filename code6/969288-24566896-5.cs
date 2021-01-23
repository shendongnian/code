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
            new { action = ”Index”, id = UrlParameter.Optional }
           );
        }
    }
