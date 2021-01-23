     public static ArrayList GetPrinters()
        {
            ArrayList ArrayPrinters = new ArrayList();
    
            PrintDocument prtdoc = new PrintDocument();
            //prt.PrinterSettings.PrinterName returns the name of the Default Printer
            string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
    
            //this will loop through all the Installed printers and add the Printer Names to a ComboBox.
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                //This will insert the Default Printer Name matches with the current Printer Name returned by for loop
                if (strPrinter.CompareTo(strDefaultPrinter) == 0)
                {
                    ArrayPrinters.Insert(0, strPrinter);
                }
                else
                {
                    ArrayPrinters.Add(strPrinter);
                }
            }
            return ArrayPrinters;
        }
