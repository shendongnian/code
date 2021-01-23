    protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (System.Web.HttpContext.Current.Session["Role"] == null) return false;
            string rol = (string)System.Web.HttpContext.Current.Session["Role"];
            var userPermittedFlag = (rol == "Admin" || rol == "Super Admin") ? PermissionsEnum.Administration : PermissionsEnum.Collaboration;
            return userPermittedFlag == this.IsPermitted;
        }
  
