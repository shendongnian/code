	public virtual void RegisterForPrinting()
	{
	   printDocument = new PrintDocument();
	   printDocumentSource = printDocument.DocumentSource;
	   printDocument.Paginate += CreatePrintPreviewPages;
	   printDocument.GetPreviewPage += GetPrintPreviewPage;
	   printDocument.AddPages += AddPrintPages;
	   PrintManager printMan = PrintManager.GetForCurrentView();
	   printMan.PrintTaskRequested += PrintTaskRequested;
	}
