        public void Configuration(IAppBuilder app) {
            app.UseCors(new CorsOptions {
                PolicyProvider = new CorsPolicyProvider {
                    PolicyResolver = context => {
                        CorsPolicy result = new CorsPolicy {
                            AllowAnyHeader = true,
                            AllowAnyMethod = true,
                            AllowAnyOrigin = false,
                            SupportsCredentials = true
                        };
                        result.Origins.Add(ConfigurationManager.AppSettings.Get("YourAllowedUrl"));
                        return Task.FromResult(result);
                    }
                }
            });
        }
