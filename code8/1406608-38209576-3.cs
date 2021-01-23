     public static class RouteConfig
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                var settings = new FriendlyUrlSettings();
                //settings.AutoRedirectMode = RedirectMode.Permanent;
                routes.EnableFriendlyUrls(settings);
            }
        }
        [WebMethod]
        public static void test(string[] arr)
        {
            
        }
