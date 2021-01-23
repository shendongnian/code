    // clone the grid you want to print, so the exception you mentioned won't happen:
    string uiToSave = XamlWriter.Save(myWindow.GetMainGrid());
    StringReader stringReader = new StringReader(uiToSave);
    XmlReader xmlReader = XmlReader.Create(stringReader);
    Grid clonedGrid = (Grid)XamlReader.Load(xmlReader);
    PrintDialog pd = new PrintDialog();
    FixedDocument document = new FixedDocument();
    document.DocumentPaginator.PageSize = new System.Windows.Size(pd.PrintableAreaWidth, pd.PrintableAreaHeight);
    // remember to set sizes again, if they're not set in xaml, for example:
    clonedGrid.Height = document.DocumentPaginator.PageSize.Height;
    clonedGrid.Width = document.DocumentPaginator.PageSize.Width;
    clonedGrid.UpdateLayout();
    FixedPage page1 = new FixedPage();
    page1.Width = document.DocumentPaginator.PageSize.Width;
    page1.Height = document.DocumentPaginator.PageSize.Height;
    // this will add the content of the whole grid to the page without problem
    page1.Children.Add(clonedGrid);
    PageContent page1Content = new PageContent();
    ((IAddChild)page1Content).AddChild(page1);
    document.Pages.Add(page1Content);
    // then print...
