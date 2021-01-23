    protected PrintDocument printDocument;
    protected IPrintDocumentSource printDocumentSource;
    List<Page> pages = new List<Page>();
    Page printPage = new PageToPrint();
    public MainPage()
    {
        this.InitializeComponent();
        RegisterForPrinting();
    }
    private async void BtnPrint_Click(object sender, RoutedEventArgs e)
    {
        await PrintManager.ShowPrintUIAsync();       
    }
    public void RegisterForPrinting()
    {
        printDocument = new PrintDocument();
        printDocumentSource = printDocument.DocumentSource;
        pages.Add(printPage);
        printDocument.GetPreviewPage += GetPrintPreviewPage;
        printDocument.AddPages += AddPrintPages;
        PrintManager printMan = PrintManager.GetForCurrentView();
        printMan.PrintTaskRequested += PrintTaskRequested;
    }
    private void AddPrintPages(object sender, AddPagesEventArgs e)
    {
        foreach (var page in pages)
        {
            printDocument.AddPage(page);
        }
        printDocument.AddPagesComplete();
    }
    private void GetPrintPreviewPage(object sender, GetPreviewPageEventArgs e)
    {
        printDocument.SetPreviewPage(1, printPage);
        printDocument.SetPreviewPageCount(pages.Count, PreviewPageCountType.Final);
    }
    void PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs e)
    {
        PrintTask printTask = null;
        printTask = e.Request.CreatePrintTask("Kimble Print Job", sourceRequested =>
        {
            printTask.Completed += PrintTask_Completed;
            sourceRequested.SetSource(printDocumentSource);
        });
    }
    private async void PrintTask_Completed(PrintTask sender, PrintTaskCompletedEventArgs args)
    {
        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
            PrintManager printMan = PrintManager.GetForCurrentView();
            printMan.PrintTaskRequested -= PrintTaskRequested;
        });
    } 
  
