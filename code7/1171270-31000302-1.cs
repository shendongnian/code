    public static class OwnResponse
    {
        public static void Redirect(string Url, bool EndResponse = true)
        {
            HttpContext.Current.Response.Redirect(Url, EndResponse); // set the breakpoint here
        }
    }
