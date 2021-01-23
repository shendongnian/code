    public class SetupMiddleware : OwinMiddleware
    {
        public SetupMiddleware(OwinMiddleware next) : base(next)
        {
            if (next == null)
            {
                throw new ArgumentNullException("next");
            }
        }
        public override async Task Invoke(IOwinContext context)
        {
            this.Log().Info("Begin request");
            IDisposable scope = null;            
            try
            {
                // here we are using IoCResolverFactory which returns an 
                //instance of IoC container
                var ioCResolver = IoCResolverFactory.GetOrCreate();
                //here we are starting new scope
                scope = ioCResolver.BeginScope();
                await Next.Invoke(context);
                this.Log().Info("End request");
            }
            catch (Exception ex)
            { 
              //here you can log exceptions
            }
            finally
            {
                //here we are desposing scope
                scope?.Dispose();
            }
        }
    }
