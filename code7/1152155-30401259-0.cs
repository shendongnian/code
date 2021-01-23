    //create the font from a ttf file
    Aspose.Pdf.Text.Font myFont =
        Aspose.Pdf.Text.FontRepository.OpenFont("C:\temp\MyFont-Regular.ttf");
    myFont.IsEmbedded = true;
    
    //new doc, add a new blank page
    Document doc = new Document();
    Page page = doc.Pages.Add();
    
    //use the font in a style
    TextState style = new TextState();
    style.Font = myFont;
    style.FontSize = 12;
    style.FontStyle = FontStyles.Regular;
    style.LineSpacing = 4;
    
    TextFragment frag = new TextFragment(sb.ToString());
    frag.TextState.ApplyChangesFrom(style);
    frag.IsInLineParagraph = true;
    page.Paragraphs.Add(frag);
    
    //save it
    doc.Save("C:\temp\fontTest.pdf");
