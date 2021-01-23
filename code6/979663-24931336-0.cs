    Range r = Paragraph.Range();
    string headingText = r.Text.Split(' ')[0];
    if (styleString.Contains("Heading"))
    // you shoul probably also tst for an empty paragraph here before inserting anything (I leave it to you)
    {
        dest = _hyperlinkDestinations.Find(x => x.HyperlinkText == headingText);
    }
    
    if (dest != null)
    {
        // Move the end of the range one character towards the beginning
        r.MoveEnd(Word.WdUnits.WdCharacter,-1)
        Hyperlink link = WordApp.ActiveWindow.Document.Hyperlinks.Add(r, Address: dest.FilePath, SubAddress: dest.bookmarkName, TextToDisplay: r.Text);
    }
