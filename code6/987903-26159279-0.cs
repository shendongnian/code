    // get the user selected printer
    var printerName = Settings.Instance[profile].DirectPrinter;
    // enumerate the printers visible to the application
    var allPrinters = PrinterSettings.InstalledPrinters.OfType<string>().OrderBy(p => p).ToList();
    // Strip out PDF, XPS and any file based printers. These cause havoc on a server based print
    var acceptablePrinters = allPrinters.Except(allPrinters
    												.Where(s => Settings.Instance[profile].PrintersToIgnore
    														.Any(u => s.ToLower().Contains(u)))).ToList();
    if (acceptablePrinters.Contains(printerName))
    {
    	report.PrintOptions.PrinterName = printerName;
    	report.PrintToPrinter(copies, collate, 0, 0);
    }
    else
    {
       // Log the reason why the printer was rejected
       // Or you may choose to just print to default
    }
