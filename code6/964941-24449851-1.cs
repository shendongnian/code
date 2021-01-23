    /// Make sure everything else stays at one column
    Paragraph oneColPara = body.AppendChild(new Paragraph());
    /// Adjust current doc properties to keep things like landscape
    SectionProperties sectionOneProps = null;
    if (body.Descendants<SectionProperties>().Count() > 0)
      sectionOneProps = (SectionProperties)body.Descendants<SectionProperties>().First().CloneNode(true);
    else
      sectionOneProps = new SectionProperties();
                
    sectionOneProps.RemoveAllChildren<Columns>();
    sectionOneProps.RemoveAllChildren<DocGrid>();
    sectionOneProps.Append(new Columns(){ Space = "708" }, new DocGrid(){ LinePitch = 360 }, new SectionType { Val = SectionMarkValues.Continuous } );
    oneColPara.Append(new ParagraphProperties(sectionOneProps));
