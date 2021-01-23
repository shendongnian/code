    Request.QueryString[BusinessLayerConstants.resetPasswordQueryString]) ? Request.QueryString[BusinessLayerConstants.resetPasswordQueryString] : String.Empty;
        passwordCode = System.Web.HttpUtility.UrlDecode(passwordCode);
    
        using (DBEntities entities = new DBEntities())
    
        {
    
        User = entities.AspNetUsers.FirstOrDefault(u => u.PasswordReset.ToLower() == passwordCode.ToLower());
    
        if (User != null)
        {
            //TODO
        }
    }
