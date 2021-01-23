    public class AdminAuthorize : AuthorizeAttribute
    {
    
        baseContext AdminContext;
    
        public AdminAuthorize()
        {
            AdminContext = new baseContext();
        }
    
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
    
            //check cookie
    
            string email = string.Empty, password = string.Empty;
            Admin TempAdmin = null;
    
            if (httpContext.Response.Cookies["adminEmail"] != null)
                email = httpContext.Response.Cookies["adminEmail"].Value;
    
            if (httpContext.Response.Cookies["adminPass"] != null)
                password = httpContext.Response.Cookies["adminPass"].Value;
    
            if (!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password))
                TempAdmin = AdminContext.admins.SingleOrDefault(u => u.Email == email && u.Pass == password);
    
                if (TempAdmin != null)
                {
                    httpContext.Session["adminID"] = TempAdmin.adminID;
                    httpContext.Session["adminNom"] = TempAdmin.Nom.ToString() + " " + TempAdmin.Prenom.ToString();
    
                    if (System.IO.File.Exists(httpContext.Server.MapPath("~" + TempAdmin.Photo)))
                    { httpContext.Session["adminPhoto"] = "~" + TempAdmin.Photo; }
                    else
                    { httpContext.Session["adminPhoto"] = "~/Content/TemplateAdmin/assets/images/no_img.png"; }
    
                    return true;
                }
            
    
            // Now check the session:
            if (httpContext.Session["adminID"] != null)
            {
                return true;
            }
    
            return false;
        }
    }
