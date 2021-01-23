<Project Sdk="Microsoft.NET.Sdk.Web">
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ObjectPool;
namespace RazorRendererNamespace
{
    /// <summary>
    /// Renders razor pages with the absolute minimum setup of MVC, easy to use in console application, does not require any other classes or setup.
    /// </summary>
    public class RazorRenderer : ILoggerFactory, ILogger
    {
        private class ViewRenderService : IDisposable, ITempDataProvider, IServiceProvider
        {
            private static readonly System.Net.IPAddress localIPAddress = System.Net.IPAddress.Parse("127.0.0.1");
            private readonly Dictionary<string, object> tempData = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            private readonly IRazorViewEngine _viewEngine;
            private readonly ITempDataProvider _tempDataProvider;
            private readonly IServiceProvider _serviceProvider;
            private readonly IHttpContextAccessor _httpContextAccessor;
            public ViewRenderService(IRazorViewEngine viewEngine,
                IHttpContextAccessor httpContextAccessor,
                ITempDataProvider tempDataProvider,
                IServiceProvider serviceProvider)
            {
                _viewEngine = viewEngine;
                _httpContextAccessor = httpContextAccessor;
                _tempDataProvider = tempDataProvider ?? this;
                _serviceProvider = serviceProvider ?? this;
            }
            public void Dispose()
            {
            
            }
            public async Task<string> RenderToStringAsync<TModel>(string viewName, TModel model, ExpandoObject viewBag = null, bool isMainPage = false)
            {
                HttpContext httpContext;
                if (_httpContextAccessor?.HttpContext != null)
                {
                    httpContext = _httpContextAccessor.HttpContext;
                }
                else
                {
                    DefaultHttpContext defaultContext = new DefaultHttpContext { RequestServices = _serviceProvider };
                    defaultContext.Connection.RemoteIpAddress = localIPAddress;
                    httpContext = defaultContext;
                }
                var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
                using (var sw = new StringWriter())
                {
                    var viewResult = _viewEngine.FindView(actionContext, viewName, isMainPage);
                    if (viewResult.View == null)
                    {
                        viewResult = _viewEngine.GetView("~/", viewName, isMainPage);
                    }
                    if (viewResult.View == null)
                    {
                        return null;
                    }
                    var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                    {
                        Model = model
                    };
                    if (viewBag != null)
                    {
                        foreach (KeyValuePair<string, object> kv in (viewBag as IDictionary<string, object>))
                        {
                            viewDictionary.Add(kv.Key, kv.Value);
                        }
                    }
                    var viewContext = new ViewContext(
                        actionContext,
                        viewResult.View,
                        viewDictionary,
                        new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
                        sw,
                        new HtmlHelperOptions()
                    );
                
                    await viewResult.View.RenderAsync(viewContext);
                    return sw.ToString();
                }
            }
            object IServiceProvider.GetService(Type serviceType)
            {
                return null;
            }
            IDictionary<string, object> ITempDataProvider.LoadTempData(HttpContext context)
            {
                return tempData;
            }
            void ITempDataProvider.SaveTempData(HttpContext context, IDictionary<string, object> values)
            {
            }
        }
        private readonly string rootPath;
        private readonly ServiceCollection services;
        private readonly ServiceProvider serviceProvider;
        private readonly ViewRenderService viewRenderer;
        public RazorRenderer(string rootPath)
        {
            this.rootPath = rootPath;
            services = new ServiceCollection();
            ConfigureDefaultServices(services);
            serviceProvider = services.BuildServiceProvider();
            viewRenderer = new ViewRenderService(serviceProvider.GetRequiredService<IRazorViewEngine>(), null, null, serviceProvider);
        }
        private void ConfigureDefaultServices(IServiceCollection services)
        {
            var environment = new HostingEnvironment
            {
                WebRootFileProvider = new PhysicalFileProvider(rootPath),
                ApplicationName = typeof(RazorRenderer).Assembly.GetName().Name,
                ContentRootPath = rootPath,
                WebRootPath = rootPath,
                EnvironmentName = "DEVELOPMENT",
                ContentRootFileProvider = new PhysicalFileProvider(rootPath)
            };
            services.AddSingleton<IHostingEnvironment>(environment);
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Clear();
                options.FileProviders.Add(new PhysicalFileProvider(rootPath));
            });
            services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
            services.AddSingleton<ILoggerFactory>(this);
            var diagnosticSource = new DiagnosticListener(environment.ApplicationName);
            services.AddSingleton<DiagnosticSource>(diagnosticSource);
            services.AddMvc();
        }
        public void Dispose()
        {
        }
        public Task<string> RenderToStringAsync<TModel>(string viewName, TModel model, ExpandoObject viewBag = null, bool isMainPage = false)
        {
            return viewRenderer.RenderToStringAsync(viewName, model, viewBag, isMainPage);
        }
        void ILoggerFactory.AddProvider(ILoggerProvider provider)
        {
            
        }
        IDisposable ILogger.BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }
        ILogger ILoggerFactory.CreateLogger(string categoryName)
        {
            return this;
        }
        bool ILogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel)
        {
            return false;
        }
        void ILogger.Log<TState>(Microsoft.Extensions.Logging.LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
        }
    }
}
