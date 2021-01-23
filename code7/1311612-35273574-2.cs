    protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (System.Web.HttpContext.Current.Session["Role"] == null) return false;
            string role = (string)System.Web.HttpContext.Current.Session["Role"];
            if ((role == "Admin" || role == "Super Admin") //recycling your condition
               && IsPermitted == PermissionsEnum.Administration) return true;
            if ((role == "Collaborator"
               && IsPermitted == PermissionsEnum.Collaborator) return true;
            
            return false;
        }
