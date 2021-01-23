    using Castle.MicroKernel;
    using Castle.MicroKernel.Lifestyle.Scoped;
    using Owin;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Web.Api.Host
    {
        using AppFunc = Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;
        public class PerWebRequestLifestyleOwinMiddleware
        {
            private readonly AppFunc next;
            private static bool _initialized;
            private static Object _syncWebRequestScope = new Object();
            private static ILifetimeScope _webRequestScope;
            public PerWebRequestLifestyleOwinMiddleware(AppFunc next)
            {
                this.next = next;
            }
            public async Task Invoke(IDictionary<string, object> environment)
            {
                _initialized = true;
                try
                {
                    await next(environment);
                }
                finally
                {
                    lock (_syncWebRequestScope)
                    {
                        if (_webRequestScope != null)
                        {
                            _webRequestScope.Dispose();
                            _webRequestScope = null;
                        }
                    }
                }
            }
            internal static ILifetimeScope GetScope()
            {
                EnsureInitialized();
                return GetScope(createIfNotPresent: true);
            }
            /// <summary>
            /// Returns current request's scope and detaches it from the request 
            /// context. Does not throw if scope or context not present. To be 
            /// used for disposing of the context.
            /// </summary>
            /// <returns></returns>
            internal static ILifetimeScope YieldScope()
            {
                var scope = GetScope(createIfNotPresent: false); // Originally was true!
                if (scope != null)
                {
                    lock(_syncWebRequestScope)
                    {
                        _webRequestScope = null;
                    }
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
            private static ILifetimeScope GetScope(bool createIfNotPresent)
            {
                if (_webRequestScope == null && createIfNotPresent)
                {
                    lock (_syncWebRequestScope)
                    {
                        if (_webRequestScope == null)
                        {
                            _webRequestScope = new DefaultLifetimeScope(new ScopeCache());
                        }
                    }
                }
                return _webRequestScope;
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
