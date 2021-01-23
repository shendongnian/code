    public sealed class Configuration : DbMigrationsConfiguration<YourEFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "YourEFContext";
        }
        /// <summary>
        /// This method will be called after migrating to the latest version.
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(YourEFContext context)
        {
            CreateUserIfNotExists(context, "someuser@email.com", "the_password");
        }
        /// <summary>
        /// Just call directly into ASP.Net Identity to check if the user exists
        /// If not, create them
        /// </summary>
        private static void CreateUserIfNotExists(YourEFContext context, string email, string password)
        {
            // Use your application user class here
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            // We're using email for the username
            if ((um.FindByEmail(email)) == null)
            {
                var au = new ApplicationUser
                {
                    UserName = email,
                    Email = email
                };
                var res = um.Create(au);
                if (res.Succeeded)
                {
                    um.AddPassword(au.Id, password);
                }
                else
                {
                    Console.WriteLine("Failed to create user: {0}", res.Errors.FirstOrDefault());
                }
            }
        }
    }
