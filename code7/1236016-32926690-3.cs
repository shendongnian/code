    public class SuccesRedirectWFFM : ClientPipelineArgs
    {
        public void Process(SubmitSuccessArgs args)
        {
            Assert.IsNotNull(args, "args");
            string returnUrl = HttpContext.Current.Request["returnUrl"]
            if (string.IsNullOrEmpty(returnUrl)) 
            {
                returnUrl = HttpUtility.ParseQueryString(HttpContext.Current.Request.UrlReferrer.Query)["returnUrl"];
            }
            if (!string.IsNullOrEmpty(returnUrl))
            {
                args.AbortPipeline();
				WebUtil.Redirect(returnUrl, false);
            }
        }
    }
