    [ValidateInput(false)]
    public ActionResult Test(string url)
    {
        var context = System.Web.HttpContext.Current;
        context.Response.Write("<html><head>");
        context.Response.Write("</head><body>");
        context.Response.Write(string.Format("<form name=\"myform\" method=\"post\" action=\"{0}\" >", HttpUtility.HtmlAttributeEncode(url)));
        context.Response.Write("</form>");
        context.Response.Write("<script type=\"text/javascript\">document.myform.submit();</script></body></html>");
        context.Response.Write("</body>");
        context.Response.Flush();
        context.Response.Clear();
        context.ApplicationInstance.CompleteRequest();
        return null;
    }
