            var configuration = WebConfigurationManager.OpenWebConfiguration("~");
            var section = (CustomErrorsSection)configuration.GetSection("system.web/customErrors");
          
            if (section != null)
            {
                @if ((BaseController)this.ViewContext.Controller).IsAdministrator())
                {
                    section.Mode = CustomErrorsMode.Off;
                }
                else
                {
                    section.Mode = CustomErrorsMode.On;
                }                
            }
            configuration.Save(); 
