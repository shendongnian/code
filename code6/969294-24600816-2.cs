    public class TransaccionesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get{
                return “Transacciones”; 
            }
        }
    
        public override void RegisterArea(AreaRegistrationContext context){
            routes.MapRoute("Transacciones_Home", "Transacciones", new { Controller = "Transacciones", Action = "Index" });
    
            context.MapRoute(
                “Transacciones_default”,
                “Transacciones/{controller}/{action}/{id}”,
                new { controller = “Transacciones”, action = ”Index”, id = UrlParameter.Option}
                );
            }
        }
    }
