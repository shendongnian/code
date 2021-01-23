    using Swashbuckle.Application;
    using System.Web.Http;
    
    public static class SwaggerExtensions
    {
        public static HttpConfiguration EnableSwagger(this HttpConfiguration httpConfiguration)
        {
            httpConfiguration
                .EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API"))
                .EnableSwaggerUi();
            return httpConfiguration;
        }
    }
