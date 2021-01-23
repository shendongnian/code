        public void Configuration(IAppBuilder app) {
            app.UseCors(new CorsOptions {
                PolicyProvider = new CorsPolicyProvider {
                    PolicyResolver = context => {
                        CorsPolicy result = new CorsPolicy {
                            AllowAnyHeader = true,
                            AllowAnyMethod = true,
                            AllowAnyOrigin = true,
                            SupportsCredentials = true
                        };                        
                        return Task.FromResult(result);
                    }
                }
            });
        }
