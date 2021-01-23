    var footerPar = document.Paragraphs.Add();
    var footerRange = footerPar.Range;
    var inlineshape = footerRange.InlineShapes.AddPicture(AppDomain.CurrentDomain.BaseDirectory + "footer.png");
    var footer = inlineshape.ConvertToShape();
    footer.Visible = Microsoft.Office.Core.MsoTriState.msoCTrue;
    footer.WrapFormat.Type = WdWrapType.wdWrapTopBottom;
    
    var inputPar = document.Paragraphs.Add();
    inputPar.Range.Text = input;
    inputPar.Range.InsertParagraphAfter();
    
    var headerPar = document.Paragraphs.Add();
    var headerRange = headerPar.Range;
    var headerShape = headerRange.InlineShapes.AddPicture(AppDomain.CurrentDomain.BaseDirectory + "header.png");
    var header = headerShape.ConvertToShape();
    header.Visible = Microsoft.Office.Core.MsoTriState.msoCTrue;
    header.WrapFormat.Type = WdWrapType.wdWrapTopBottom;
