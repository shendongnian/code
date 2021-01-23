     public static void getPrintJob()
        {
            string printerName = "Some Printer Name";
            string query = string.Format("SELECT * from Win32_Printer WHERE Name LIKE '%{0}'", printerName);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection coll = searcher.Get();
            
            while(true)
            {
			    ManagementObjectCollection coll = searcher.Get();
			    var alreadyPrinting = false;
                foreach (ManagementObject printer in coll)
                {
                   if (Convert.ToInt32(printer.Properties["PrinterStatus"].Value) == 4 && !alreadyPrinting)
                   {
                       Console.Write("Printer is Printing");
				       alreadyPrinting = true;
                   }
			       else
			       {
			   	        alreadyPrinting = false;
			       }
                }
                Thread.Sleep(1000);
            }
        }
