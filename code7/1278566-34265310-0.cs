    // Show the print dialog
    var dlg = new PrintDialog();
    if (!dlg.ShowDialog().GetValueOrDefault())
    {
        // User cancelled
        return;
    }
    // Create and initialise the FlowDocument
    _doc = new FlowDocument();
    _doc.FontFamily = new FontFamily("Arial");
    _doc.FontSize = 14;
    // Add a paragraph of text
    var para = new Paragraph(new Run("My paragraph....."))
    {
        FontSize = 14,
        Foreground = new SolidColorBrush(Colors.Black),
        Margin = new Thickness(0,0,0,12)
    };
    _doc.Blocks.Add(para);
    // Add an image
    var para = new Paragraph();
    var img = new Image
    {
        Source = bitmapSource, 
        HorizontalAlignment = HorizontalAlignment.Center, 
        Margin = new Thickness(0,0,0,12)
    };
    para.Inlines.Add(img);
    _doc.Blocks.Add(para);
    // Print
    var documentPaginator = ((IDocumentPaginatorSource)_doc).DocumentPaginator;
    dlg.PrintDocument(documentPaginator, "My print job");
