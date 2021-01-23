    using Castle.MicroKernel.Context;
    using Castle.MicroKernel.Lifestyle.Scoped;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Web.Api.Host
    {
        public class OwinWebRequestScopeAccessor : IScopeAccessor
        {
            public void Dispose()
            {
                var scope = PerWebRequestLifestyleOwinMiddleware.YieldScope();
                if (scope != null)
                {
                    scope.Dispose();
                }
            }
            public ILifetimeScope GetScope(CreationContext context)
            {
                return PerWebRequestLifestyleOwinMiddleware.GetScope();
            }
        }
    }
