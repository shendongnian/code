    using System.Configuration;
    System.Drawing.Printing.PrinterSettings pagina = new    System.Drawing.Printing.PrinterSettings(); 
                pagina.PrinterName=ConfigurationSettings.AppSettings["textBox_ImpNOMBRE"];//default printer name
    //ADD OTHER CONFIGURATIONS SETTINGS
            reportViewer1.PrinterSettings = pagina;
