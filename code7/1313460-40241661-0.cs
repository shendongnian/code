    public class GlobalSettings : IGlobalSettings
        {
            private IHttpContextAccessor _accessor;
    
            public GlobalSettings(IHttpContextAccessor accessor)
            {
                _accessor = accessor;
            }    
    
            public string RefNo
            {
                get
                {
                    return GetValue(_accessor.HttpContext.User, "employeeid");
                }
            }
    
            public string SAMAccount
            {
                get
                {
                    return GetValue(_accessor.HttpContext.User, ClaimTypes.WindowsAccountName);
                }
            }
    
            public string UserName
            {
                get
                {
                    return GetValue(_accessor.HttpContext.User, ClaimTypes.Name);
                }
            }
    
            public string Role
            {
                get
                {
                    return GetValue(_accessor.HttpContext.User, ClaimTypes.Role);
                }
            }
    
            private string GetValue(ClaimsPrincipal principal, string key)
            {
                if (principal == null)
                    return string.Empty;
    
                return principal.FindFirstValue(key);
            }
    }
