    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.IO;
    using System.Runtime.Loader;
    
    namespace AppPartTest1.Web.Helpers.Features
    {
        public static class FeaturesBuilderExtensions
        {
            //
            // Summary:
            //     Adds Features supports to the Application.
            //
            // Parameters:
            //   builder:
            //     The Microsoft.Extensions.DependencyInjection.IMvcBuilder.
            public static IMvcBuilder AddFeaturesSupport(this IMvcBuilder builder, IConfigurationRoot Configuration, IHostingEnvironment environment)
            {
    
                var fileNames = Directory.GetFiles("Features", "*.dll");
    
                foreach (string fileName in fileNames)
                {
                    builder.AddApplicationPart(AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.Combine(environment.ContentRootPath, fileName)));
                }
    
                return builder;
            }
        }
    }
