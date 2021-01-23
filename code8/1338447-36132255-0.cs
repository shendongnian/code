    public void ProcessRequest(HttpContext context)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated == false)
            {
                context.Response.Redirect("Your Path");
            }
        }
