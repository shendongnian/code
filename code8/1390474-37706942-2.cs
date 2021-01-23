    var rtb = new RichTextBlock();
    var paragraph = new Paragraph();
    var bold1 = new Bold();
    bold1.Inlines.Add(new Run() { Text = "I am Bold" });
    paragraph.Inlines.Add(bold1);
    var normalText = new Run() { Text = " I am Normal" };
    paragraph.Inlines.Add(normalText);
    var bold2 = new Bold();
    bold2.Inlines.Add(new Run() { Text = " I am more Bold" });
    paragraph.Inlines.Add(bold2);
    rtb.Blocks.Add(paragraph);
    LayoutGrid.Children.Add(rtb); //Grid in your xaml
