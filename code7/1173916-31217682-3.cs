        [System.Web.Services.WebMethod]
        public static void CheckIfSessionIsNull()
        {
           if (System.Web.HttpContext.Current.Session["UserId"] == null)
              HttpContext.Current.Response.Redirect("Login.aspx");
        }
