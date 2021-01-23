    // register configuration
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IConfiguration>(Configuration);
    }
    public static class ControllerExtension
    {
        public static string RenderPartialToString(this Controller controller, string viewName, object model)
        {
            controller.ViewData.Model = model;
            var config = controller.HttpContext.RequestServices.GetService<IConfiguration>();
            // other stuff
        }
    }
