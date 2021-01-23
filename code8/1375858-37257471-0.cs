    public static string url(string example)
    {
        string back = "";
        if (example == "random1")
        {
            back = HttpContext.Current.Request.Url.AbsolutePath.ToString();
        }
        return back;
    }
