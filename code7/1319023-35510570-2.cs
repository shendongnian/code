    // using System.Web.UI
    StringWriter stringWriter = new StringWriter();
    using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
    {
        writer.AddAttribute(HtmlTextWriterAttribute.Id, "ctl00_BodyPlaceHolder_Label2");
        writer.RenderBeginTag(HtmlTextWriterTag.Span);
        foreach (var content in contentList.OrderBy(c => c.Title))
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "justPad");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "defaultLinks");
            writer.AddAttribute(HtmlTextWriterAttribute.Href, content.Quicklink);
            writer.AddAttribute(HtmlTextWriterAttribute.Title, content.Title);
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.WriteEncodedText(content.Title);
            writer.RenderEndTag();
            writer.RenderEndTag();
        }
        writer.RenderEndTag();
    }
