    public static string GetHtmlTableString(HtmlTable table)
    {
        string retval = "";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        table.RenderControl(htw);
        return sw.ToString();
    }
