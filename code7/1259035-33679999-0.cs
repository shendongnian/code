    public static string GetString(IHtmlContent content)
    {
        var writer = new System.IO.StringWriter();
        content.WriteTo(writer, new HtmlEncoder());
        return writer.ToString();
    }
