    protected void Page_Load(object sender, EventArgs e)
    {
        string returnURL = Request.QueryString["ReturnUrl"];
        if (!string.IsNullOrEmpty(returnURL))
        {
    // Test for the exclusion
        if (returnURL.Length > 7)
            {
                if (returnURL.Substring(1, 7) == "Webinar")  // or whatever you want to continue on to processing
                {
                    Response.Redirect(returnURL);
                }
                if (returnURL.Substring(1, 9) == "subscribe")  // or whatever you want to continue on to processing
                {
                    Response.Redirect(returnURL);
                }
            }
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect(returnURL);  // this exists to allow users to re-log in if the session has not timed out
            }
        }
        RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);  // use this if you want the person directed to a registration page
        ResendEmailHyperLink.NavigateUrl = "Resend.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);  // use this if you want the person to have the registration email resent to them
        ResetHyperLink.NavigateUrl = "ResetPassword.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);  // use this to allow the user to reset their password
    }
