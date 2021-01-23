    public void Print()
    {
        PrintDialog pd = new PrintDialog();
        if(pd.ShowDialog() == true) //allow user to pick printer and preferences if they choose to do so
        {
            FlowDocument document = Application.LoadComponent(new Uri("/someassembly;component/somepath.xaml", UriKind.Relative)) as FlowDocument;
            
            document.DataContext = new LabelTicket(); //stores data for printing
            Grid g = new Grid();
            ContentPresenter cp = new ContentPresenter();
            cp.Content = document;
            g.Children.Add(cp);
            var _printableAreaSize = new Size(pd.PrintableAreaWidth, pd.PrintableAreaHeight);
            g.Measure(_printableAreaSize);
            g.Arrange(new Rect(new Point(), _printableAreaSize));
            g.UpdateLayout();
            DocumentPaginator dp = ((IDocumentPaginatorSource)document).DocumentPaginator;
            pd.PrintDocument(dp, "someTitle");
        }
    }
