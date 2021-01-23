    using System;
    using System.Diagnostics;
    using System.IO;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Hosting.Internal;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.FileProviders;
    using Microsoft.Extensions.ObjectPool;
    using Microsoft.Extensions.PlatformAbstractions;
    
    namespace RenderRazorToString
    {
        public class Program
        {
            public static void Main()
            {
                // Initialize the necessary services
                var services = new ServiceCollection();
                ConfigureDefaultServices(services);
                var provider = services.BuildServiceProvider();
    
                var renderer = provider.GetRequiredService<RazorViewToStringRenderer>();
    
                // Build a model and render a view
                var model = new EmailViewModel
                {
                    UserName = "User",
                    SenderName = "Sender"
                };
                var emailContent = renderer.RenderViewToString("EmailTemplate", model).GetAwaiter().GetResult();
    
                Console.WriteLine(emailContent);
                Console.ReadLine();
            }
    
            private static void ConfigureDefaultServices(IServiceCollection services)
            {
                var applicationEnvironment = PlatformServices.Default.Application;
                services.AddSingleton(applicationEnvironment);
    
                var appDirectory = Directory.GetCurrentDirectory();
    
                var environment = new HostingEnvironment
                {
                    WebRootFileProvider = new PhysicalFileProvider(appDirectory),
                    ApplicationName = "RenderRazorToString"
                };
                services.AddSingleton<IHostingEnvironment>(environment);
    
                services.Configure<RazorViewEngineOptions>(options =>
                {
                    options.FileProviders.Clear();
                    options.FileProviders.Add(new PhysicalFileProvider(appDirectory));
                });
    
                services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
    
                var diagnosticSource = new DiagnosticListener("Microsoft.AspNetCore");
                services.AddSingleton<DiagnosticSource>(diagnosticSource);
    
                services.AddLogging();
                services.AddMvc();
                services.AddSingleton<RazorViewToStringRenderer>();
            }
        }
    }
