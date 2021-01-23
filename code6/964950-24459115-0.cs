        private async void SeedUser()
        {
            using (var context = new DataContext()) {
                var newUser = new User() { UserName = "buzzlightyear@pixar.com", Email = "buzzlightyear@pixar.com", Name = "Buzz Lightyear" };
                var userManager = new IdentityManager(new UserStore<User>(context));
                var result = await userManager.CreateAsync(newUser, "infinityandbeyond");
                if (!result.Succeeded) {
                    Assert.Fail("Failed to set up User for TestBase.");
                }
                var user = context.Users.FirstOrDefault();
                if (user == null) {
                    Assert.Fail("The User was not found in the database.");
                }
                this.UserId = user.Id;
            }
        }
