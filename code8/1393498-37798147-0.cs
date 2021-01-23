    private static InvoiceReceipt _mappedInvoice ;
    private readonly static Object _lockObject = new Object();
    public static void PrintReceipt(InvoiceReceipt invoiceReceipt)
    {
        Lock(_lockObject)
        {
            _mappedInvoice = invoiceReceipt;
            var printNodeIntegration = new PrintNodeIntegration();
            printNodeIntegration.Print(GetDocument(), invoiceReceipt.PrinterName);
        }
    }
