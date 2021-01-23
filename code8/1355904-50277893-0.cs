    var claim = HttpContext.User.CurrentUserID();
    public static class XYZ
    {
        public static int CurrentUserID(this ClaimsPrincipal claim)
        {
            var userID = claimsPrincipal.Claims.ToList().Find(r => r.Type == 
             "UserID").Value;
            return Convert.ToInt32(userID);
        }
        public static string CurrentUserRole(this ClaimsPrincipal claim)
        {
            var role = claimsPrincipal.Claims.ToList().Find(r => r.Type == 
            "Role").Value;
            return role;
        }
    }
   
   
