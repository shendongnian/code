         <RichTextBlock x:Name="textblock"/>
    
     Run run1 = new Run();
    run1.Text = "some text";
    HyperlinkButton hyperlinkButton = new HyperlinkButton()
    {
        Content = " read more..",
        HorizontalAlignment = HorizontalAlignment.Left,
        NavigateUri = new Uri("http://somelink.com", UriKind.Absolute)
    };
    Paragraph para = new Paragraph();
    InlineUIContainer inline = new InlineUIContainer();
    inline.Child = hyperlinkButton;
    para.Inlines.Add(run1);
    para.Inlines.Add(inline);
    textblock.Blocks.Add(para);
