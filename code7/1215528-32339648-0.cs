    public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
    {
        // some code here...
        await EmailHelper.SendReset(Url, model.Email);
        //...
    }
    public static class EmailHelper
    {
        public static async Task SendReset(UrlHelper urlHelper, string emailAddress)
        {
            //...
            string url = urlHelper.AbsoluteAction("Login", "Account");
        }
    }
