    public class Impersonate
    {
        private readonly RequestDelegate next;
        public Impersonate(RequestDelegate next) {
            this.next = next;
        }
        public async Task Invoke(HttpContext context) {
            var winIdent = context.User.Identity as WindowsIdentity;
            if (winIdent == null) {
                await next.Invoke(context);
            }else {
                WindowsIdentity.RunImpersonated(winIdent.AccessToken, () => {
                    next.Invoke(context).Wait();
                });
            }
        }
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
        ....
        app.UseMiddleware<Impersonate>();
        app.UseMvc(...);
        ...
    }
