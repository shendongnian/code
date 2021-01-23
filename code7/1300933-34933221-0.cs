    public partial class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
               //non relevant code skipped
               services.AddMvc().AddRazorOptions(ConfigureRazor);
    		   
            }
            
            public void ConfigureRazor(RazorViewEngineOptions razor)
            {
                razor.ViewLocationExpanders.Add(new ViewLocationExpander());
            }
        }
