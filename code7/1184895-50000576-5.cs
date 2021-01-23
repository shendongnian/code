    public class StartinMiddleware : OwinMiddleware
    {
        public StartinMiddleware(OwinMiddleware next) : base(next)
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
                // here we are using IoCResolverFactory which returns 
                // the instance of IoC container(which will be singleton for the 
                // whole application)
                var container= IoCResolverFactory.GetOrCreate();
                //here we are starting new scope
                scope = container.BeginScope();
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
