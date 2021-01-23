    string html;
    using (var sw = new StringWriter())
    using (var hw = new HtmlTextWriter(sw))
    {
        hw.RenderBeginTag(HtmlTextWriterTag.Tr);
        hw.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, "green");
        hw.RenderBeginTag(HtmlTextWriterTag.Td);
        hw.RenderEndTag();
        hw.RenderEndTag();
        html = sw.ToString();
    }
