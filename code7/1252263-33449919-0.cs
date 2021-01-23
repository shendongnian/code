    public class MyTextAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MyText";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "MyText_default",
                url: "MyText/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
    }
