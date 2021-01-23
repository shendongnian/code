    //nuget: Install-Package Castle.Core
    using System;
    using Castle.DynamicProxy;
    public class ApiClientFactory
    {
        public class ApiClient : IApiClient
        {
            [ApiVersionRange(10, 20)]
            public void Foo()
            {
                Console.Write("Foo");
            }
            public int GetCurrentVersion()
            {
                // call to the server here instead :)
                return 50;
            }
        }
        public IApiClient CreateClient()
        {
            var generator = new ProxyGenerator();
            var apiClient = generator.CreateInterfaceProxyWithTarget<IApiClient>(
              new ApiClient(), new VersionInterceptor());
            return apiClient;
        }
    }
    public class VersionInterceptor : StandardInterceptor
    {
        protected override void PreProceed(IInvocation invocation)
        {
            var attributes = invocation.MethodInvocationTarget.GetCustomAttributes(
              typeof(ApiVersionRangeAttribute), false);
            if (attributes != null && attributes.Length == 1)
            {
                var apiRange = (ApiVersionRangeAttribute)attributes[0];
                var proxy = (IApiClient)invocation.Proxy;
                apiRange.Validate(proxy.GetCurrentVersion());
            }
            base.PreProceed(invocation);
        }
    }
