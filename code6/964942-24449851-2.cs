    int LeftWidth = 2000;
    int RightWidth = 2000;
    int NumberOfCols = 2;
    Table leftTable = StartTable(NumberOfCols, LeftWidth); // Create a basic table
    Table rightTable = StartTable(NumberOfCols, RightWidth);
    /// Need this blank para to line tables up
    body.Append(new Paragraph());
    
    body.Append(leftTable);
    
    /// Place the tables side by side
    body.Append(new Paragraph(new Run(new Break() { Type = BreakValues.Column })));
    
    body.Append(rightTable);
    /// Make section have 2 columns
    Paragraph twoColPara = body.AppendChild(new Paragraph());
    /// Adjust current doc properties to keep things like landscape
    SectionProperties sectionTwoProps = null;
    if (body.Descendants<SectionProperties>().Count() > 0)
      sectionTwoProps = (SectionProperties)body.Descendants<SectionProperties>().First().CloneNode(true);
    else
      sectionTwoProps = new SectionProperties();
    sectionTwoProps.RemoveAllChildren<Columns>();
    sectionTwoProps.RemoveAllChildren<DocGrid>();
    sectionTwoProps.Append(new Columns() { Space = "284", ColumnCount = 2 }, new DocGrid() { LinePitch = 360 }, new SectionType { Val = SectionMarkValues.Continuous });
    twoColPara.Append(new ParagraphProperties(sectionTwoProps));
