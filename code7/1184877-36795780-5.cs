    using Castle.MicroKernel;
    using Castle.MicroKernel.Lifestyle.Scoped;
    using Owin;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Web.Api.Host
    {
        using AppFunc = Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;
        public class PerWebRequestLifestyleOwinMiddleware
        {
            private readonly AppFunc _next;
            private const string c_key = "castle.per-web-request-lifestyle-cache";
            private static bool _initialized;
            public PerWebRequestLifestyleOwinMiddleware(AppFunc next)
            {
                _next = next;
            }
            public async Task Invoke(IDictionary<string, object> environment)
            {
                var requestContext = OwinRequestScopeContext.Current;
                _initialized = true;
                try
                {
                    await _next(environment);
                }
                finally
                {
                    var scope = GetScope(requestContext, createIfNotPresent: false);
                    if (scope != null)
                    {
                        scope.Dispose();
                    }
                    requestContext.EndRequest();
                }
            }
            internal static ILifetimeScope GetScope()
            {
                EnsureInitialized();
                var context = OwinRequestScopeContext.Current;
                if (context == null)
                {
                    throw new InvalidOperationException(typeof(OwinRequestScopeContext).FullName +".Current is null. " +
                        typeof(PerWebRequestLifestyleOwinMiddleware).FullName +" can only be used with OWIN.");
                }
                return GetScope(context, createIfNotPresent: true);
            }
            /// <summary>
            /// Returns current request's scope and detaches it from the request 
            /// context. Does not throw if scope or context not present. To be 
            /// used for disposing of the context.
            /// </summary>
            /// <returns></returns>
            internal static ILifetimeScope YieldScope()
            {
                var context = OwinRequestScopeContext.Current;
                if (context == null)
                {
                    return null;
                }
                var scope = GetScope(context, createIfNotPresent: false);
                if (scope != null)
                {
                    context.Items.Remove(c_key);
                }
                return scope;
            }
            private static void EnsureInitialized()
            {
                if (_initialized)
                {
                    return;
                }
                throw new ComponentResolutionException("Looks like you forgot to register the OWIN middleware " + typeof(PerWebRequestLifestyleOwinMiddleware).FullName);
            }
            private static ILifetimeScope GetScope(IOwinRequestScopeContext context, bool createIfNotPresent)
            {
                ILifetimeScope candidates = null;
                if (context.Items.ContainsKey(c_key))
                {
                    candidates = (ILifetimeScope)context.Items[c_key];
                }
                else if (createIfNotPresent)
                {
                    candidates = new DefaultLifetimeScope(new ScopeCache());
                    context.Items[c_key] = candidates;
                }
                return candidates;
            }
        }
        public static class AppBuilderPerWebRequestLifestyleOwinMiddlewareExtensions
        {
            /// <summary>
            /// Use <see cref="PerWebRequestLifestyleOwinMiddleware"/>.
            /// </summary>
            /// <param name="app">Owin app.</param>
            /// <returns></returns>
            public static IAppBuilder UsePerWebRequestLifestyleOwinMiddleware(this IAppBuilder app)
            {
                return app.Use(typeof(PerWebRequestLifestyleOwinMiddleware));
            }
        }
    }
