    public static string GetString(IHtmlContent content)
    {
        using (var writer = new System.IO.StringWriter())
        {        
            content.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        } 
    }     
