    PrintSettings settings = new PrintSettings();
    settings.PaperSize = new PaperSize("XXX", "XXX", 500, 5000);
    
    PageSetup setup = new PageSetup();
    setup.SetBottomMargin(0, Unit.Pixel);
    setup.SetTopMargin(0, Unit.Pixel);
    setup.SetLeftMargin(0, Unit.Pixel);
    setup.SetRightMargin(0, Unit.Pixel);
    setup.PaperSize = settings.PaperSize;
    
    PrintOperation print = new PrintOperation();
    print.DefaultPageSetup = setup;
    print.PrintSettings = settings;
    
    print.BeginPrint += new BeginPrintHandler(OnBeginPrint);
    print.DrawPage += new DrawPageHandler(OnDrawPage);
    print.EndPrint += new EndPrintHandler(OnEndPrint);
    print.Run(PrintOperationAction.Print, null);
