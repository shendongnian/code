        internal static void Main(string[] args)
        {
            _userStore = new UserStore<ApplicationUser>(new IdentityDbContext<ApplicationUser>());
            _userManager = new UserManager<ApplicationUser>(_userStore);
            var x = new ApplicationUser();
            x.UserName = "Test";
            foreach(string error in _userManager.Create(x, "password").Errors)
            {
                Console.WriteLine(error);
            }
            Console.WriteLine(_userManager.CheckPassword(x, "password"));
            var f = ChangePasswordAsync(x, "password", "pass12345");
            f.ContinueWith(delegate
            {
                if (f.IsFaulted)
                {
                    Console.WriteLine(f.Exception.Message);
                }
            }).ContinueWith(delegate
            {
                Console.WriteLine(_userManager.CheckPassword(x, "password"));
            });
            Console.ReadKey(true);
        }
        private static UserStore<ApplicationUser> _userStore;
        public class ApplicationUser : IdentityUser { }
        private static UserManager<ApplicationUser> _userManager;
        
        public static Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword)
        {
            return _userManager.ChangePasswordAsync(user.Id, currentPassword, newPassword);
        }
[Edit]
Using any version of Microsoft.AspNet.Identity.Core I get
[![enter image description here][1]][1]
for the parameters of the constructor.
  [1]: http://i.stack.imgur.com/WbNuX.png
