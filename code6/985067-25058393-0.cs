    using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(documentStream, true))
    {
        MainDocumentPart mainPart = wordDocument.MainDocumentPart;
        Body body = wordDocument.MainDocumentPart.Document.Body;
        Paragraph para = body.AppendChild(new Paragraph());
        StyleDefinitionsPart part = wordDocument.MainDocumentPart.StyleDefinitionsPart;
        if (part != null)
        {
            Style style = new Style()
            {
                Type = StyleValues.Paragraph,
                StyleId = "Heading1",
                BasedOn = new BasedOn() { Val = "Normal" },
                NextParagraphStyle = new NextParagraphStyle() { Val = "Normal" }
            };
            StyleName styleName1 = new StyleName() { Val = "heading 1" };
            style.Append(styleName1);
            style.Append(new PrimaryStyle());
            StyleRunProperties styleRunProperties1 = new StyleRunProperties();
            styleRunProperties1.Append(new Bold());
            styleRunProperties1.Append(new RunFonts() 
                {
                    ComplexScriptTheme=ThemeFontValues.MajorBidi, 
                    HighAnsiTheme=ThemeFontValues.MajorHighAnsi,
                    EastAsiaTheme=ThemeFontValues.MajorEastAsia, 
                    AsciiTheme=ThemeFontValues.MajorAscii 
                });
            styleRunProperties1.Append(new FontSize() { Val = "28" });
            styleRunProperties1.Color = new Color() 
                {
                    Val = "365F91",
                    ThemeShade = "BF",
                    ThemeColor = ThemeColorValues.Accent1
                };
            style.Append(styleRunProperties1);
            part.Styles.Append(style);
            ParagraphProperties pPr = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId() { Val = "Heading1" };
            pPr.Append(paragraphStyleId1);
            para.Append(pPr);
        }
        Run run = para.AppendChild(new Run());
        run.AppendChild(new Text("This is a heading"));
    }
