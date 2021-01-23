    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "SwashbuckleExample");
                    c.DocumentFilter<AuthorizeRoleFilter>();
                })
                .EnableSwaggerUi(c => { });
        }
    }
