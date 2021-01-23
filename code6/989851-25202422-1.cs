    Run myRun = new Run();
    myRun.Text = "Displaying text with ";
    Hyperlink link = new Hyperlink();
    link.Inlines.Add("hyperlink");
    link.NavigateUri = new Uri("http://stackoverflow.com/");
    link.TargetName = "_blank";
    link.Foreground = new SolidColorBrush(Colors.Blue);
    
    Paragraph myParagraph = new Paragraph();
    myParagraph.Inlines.Add(myRun);
    myParagraph.Inlines.Add(link);
    
    myRun = new Run();
    myRun.Text = " and with some text after the link.";
    myParagraph.Inlines.Add(myRun);
    rtb.Blocks.Add(myParagraph);
