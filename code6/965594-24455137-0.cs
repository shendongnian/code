    protected override void RequestStartup(TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);
            var credentials = ExtractCredentialsFromRequest(context);
            if(credentials !=null)
                context.CurrentUser = container.Resolve<IUserValidator>().Validate(credentials[0], credentials[1]);
        }
        private string[] ExtractCredentialsFromRequest(NancyContext context)
        {
            var authHeader = context.Request.Headers["Authorization"].SingleOrDefault();
            if (authHeader == null)
                return null;
            var credentials = authHeader.Split(new[]{':'}, StringSplitOptions.RemoveEmptyEntries);
            if (credentials.Length != 2)
                return null;
            return credentials;
        }
