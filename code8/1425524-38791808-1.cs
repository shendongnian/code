    hw.RenderBeginTag(HtmlTextWriterTag.Tr);
    if(makeThisGreen)
        hw.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, "green");
    if(makeThisBold)
        hw.AddStyleAttribute(HtmlTextWriterStyle.FontWeight, "bold");
    hw.RenderBeginTag(HtmlTextWriterTag.Td);
    hw.RenderEndTag();
    hw.RenderEndTag();
