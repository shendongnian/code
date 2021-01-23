    public static string HtmlContentToString(IHtmlContent content, HtmlEncoder encoder = null)
            {
                if (encoder == null)
                {
                    encoder = new HtmlTestEncoder();
                }
    
                using (var writer = new StringWriter())
                {
                    content.WriteTo(writer, encoder);
                    return writer.ToString();
                }
            }
