    public class ClaimsCookie
        {
            private readonly ClaimsPrincipal _user;
            private readonly HttpContext _httpContext;
            public ClaimsCookie(ClaimsPrincipal user, HttpContext httpContext = null)
            {
                _user = user;
                _httpContext = httpContext;
            }
    
            public string GetValue(CookieName cookieName, KeyName keyName)
            {
                var principal = _user as ClaimsPrincipal;
                var cp = principal.Identities.First(i => i.AuthenticationType == ((CookieName)cookieName).ToString());
                return cp.FindFirst(((KeyName)keyName).ToString()).Value;
            }
            public async void SetValue(CookieName cookieName, KeyName[] keyName, string[] value)
            {
                if (keyName.Length != value.Length)
                {
                    return;
                }
                var principal = _user as ClaimsPrincipal;
                var cp = principal.Identities.First(i => i.AuthenticationType == ((CookieName)cookieName).ToString());
                for (int i = 0; i < keyName.Length; i++)
                {
                    if (cp.FindFirst(((KeyName)keyName[i]).ToString()) != null)
                    {
                        cp.RemoveClaim(cp.FindFirst(((KeyName)keyName[i]).ToString()));
                        cp.AddClaim(new Claim(((KeyName)keyName[i]).ToString(), value[i]));
                    }
    
                }
                await _httpContext.SignOutAsync(CookieName.UserProfilCookie.ToString());
                await _httpContext.SignInAsync(CookieName.UserProfilCookie.ToString(), new ClaimsPrincipal(cp),
                    new AuthenticationProperties
                    {
                        IsPersistent = bool.Parse(cp.FindFirst(KeyName.IsPersistent.ToString()).Value),
                        AllowRefresh = true
                    });
            }
            public enum CookieName
            {
                CompanyUserProfilCookie = 0, UserProfilCookie = 1, AdminPanelCookie = 2
            }
            public enum KeyName
            {
                Id, Name, Surname, Image, IsPersistent
            }
        }
