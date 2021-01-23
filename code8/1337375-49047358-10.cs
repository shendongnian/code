    public class UserManager
    {
        string _connectionString;
        public UserManager(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async void SignIn(HttpContext httpContext, UserDbModel user, bool isPersistent = false)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var queryString = "sp_user_login";
                var dbUserData = con.Query<UserDbModel>(
                    queryString,
                    new
                    {
                        UserEmail = user.UserEmail,
                        UserPassword = user.UserPassword,
                        UserCellphone = user.UserCellphone
                    },
                    commandType: CommandType.StoredProcedure
                ).FirstOrDefault();
                ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(dbUserData), CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            }
        }
        public async void SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }
        private IEnumerable<Claim> GetUserClaims(UserDbModel user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id().ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.UserFirstName));
            claims.Add(new Claim(ClaimTypes.Email, user.UserEmail));
            claims.AddRange(this.GetUserRoleClaims(user));
            return claims;
        }
        private IEnumerable<Claim> GetUserRoleClaims(UserDbModel user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id().ToString()));
            claims.Add(new Claim(ClaimTypes.Role, user.UserPermissionType.ToString()));
            return claims;
        }
    }
