        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);
            if (context.Request.Headers["Authorization"].SingleOrDefault() == null)
            {
                //no Authorization header found / request cannot be authenicated using token authentication. Enable Form authentication.
                var formsAuthConfiguration = new FormsAuthenticationConfiguration()
                {
                    RedirectUrl = "~/user/login",
                    UserMapper = container.Resolve<IUserMapper>()
                };
                FormsAuthentication.Enable(pipelines, formsAuthConfiguration);
            }
            else
            {
                //Authorization header found. Enable Token authentication.
                TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(container.Resolve<ITokenizer>()));
            }           
        }
