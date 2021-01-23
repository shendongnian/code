            services.ConfigureApplicationCookie(options =>
            {
                options.Events = new CookieAuthenticationEvents(){
                ...
                };
            }
