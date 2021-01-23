    // clone element
    var clonedElement = CloneElementAndSetContentInPlaceholders(datacontext);
    
    // search the first created paragraph on my clonedElement
    Paragraph p = clonedElement.Descendants<Paragraph>().FirstOrDefault();
    if (p != null)
        p.PrependChild<ParagraphProperties>(new ParagraphProperties());
    // get the paragraph properties
    ParagraphProperties pPr = p.Elements<ParagraphProperties>().First();
    // apply style
    pPr.ParagraphStyleId = new ParagraphStyleId { Val = "FormationTitre2" };
    // set content of content control
    SetContentOfContentControl(clonedElement, item.Value);
