    public class ContextSettingsMiddleware
    {
        private readonly RequestDelegate _next;
        public ContextSettingsMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IServiceProvider serviceProvider, IHostingEnvironment env, IContextSettings contextSettings)
        {
            var customerName = context.Request.Headers["customer"];
            var customer = SettingsProvider.Instance.Settings.Customers.FirstOrDefault(c => c.Name == customerName);
            contextSettings.SetCurrentCustomer(customer);
            await _next.Invoke(context);
        }
    }
