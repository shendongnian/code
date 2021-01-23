    public interface SendPrinterDocumentResponse
    {
        event EventHandler PrintingFinished;
        event EventHandler<PrintingInterruptedEventArgs> PrintingInterrupted;
        void Retry();
    }
    public class PrintingInterruptedEventArgs: EventArgs
    {
         public string Reason { get;set; }
    }
