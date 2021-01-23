    PrintSettings settings = new PrintSettings();
    settings.Printer = "MY SECONDARY PRINTER";
    PrintOperation print = new PrintOperation();
    print.PrintSettings = settings;
    
    print.BeginPrint += new BeginPrintHandler(OnBeginPrint);
    print.DrawPage += new DrawPageHandler(OnDrawPage);
    print.EndPrint += new EndPrintHandler(OnEndPrint);
    
    print.Run(PrintOperationAction.Print, null);
