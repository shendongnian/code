        public static String GetCurrentUserId()
        {
            var administrationService = GetServiceReferenceInstance();
            var identity = (WindowsIdentity)HttpContext.Current.User.Identity;
            administrationService.Credentials = CredentialCache.DefaultCredentials;
            using (var impersonationContext = identity.Impersonate())
            {
                return administrationService.CurrentUsers.ToList().First().Identity;
            }
        }
        private static Contracts.CurrentUserData.Administration GetServiceReferenceInstance()
        {
            return new Contracts.CurrentUserData.Administration(new Uri(ConfigurationManager.AppSettings["AKey"]));
        }
