        try
        {
            if (_httpContextAccessor.HttpContext.Session.GetString("CompanyCode") != null)
            {
                queryArgs.CompanyCode = _httpContextAccessor.HttpContext.Session.GetString("CompanyCode").ToString();
            }
        }
       catch(Exception ex)
       {
            Response.Redirect("controllerName/ActionName");
       }
