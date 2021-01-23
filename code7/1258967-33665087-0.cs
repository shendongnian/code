    [WebMethod(EnableSession=true)]
    public static void UpdateProjectName(string name)
    {
            string project_id = HttpContext.Current.Request.Url.AbsoluteUri.ToString();
    }
