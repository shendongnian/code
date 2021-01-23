    public abstract class tech : WebViewPage
    {
        public static bool isInRole(string roles) {
            string ID = HttpContext.Current.User.Identity.Name;
            
            //This if to skip query Db, if user are in the same session
            if (HttpContext.Current.Session["roles"] == null)
            {
                var db = new UserDbContext();
                HttpContext.Current.Session["roles"] = db.UserRoles
                        .Where(a => a.User.Username == ID)
                        .Select(a => a.Role.Rolename).ToArray();
            }
            string[] arrRole = (string[])(HttpContext.Current.Session["roles"]);
            char[] delimiters = new char[] { ',' };
            string[] inRoles = roles.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return arrRole.Intersect(inRoles, StringComparer.OrdinalIgnoreCase).Any();
        }
    }
