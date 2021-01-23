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
                await WindowsIdentity.RunImpersonated(winIdent.AccessToken, async () => {
                    await next.Invoke(context);
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
