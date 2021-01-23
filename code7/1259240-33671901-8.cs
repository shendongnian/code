    public void SendPrinterDocument(string documentName, ISendPrinterEvents events);
    {
         // when interrupted
         if(events.PrintingInterrupted != null)
         {
               events.PrintingInterrupted(this, new PrintingInterruptedEventArgs{Reason = "Out of paper"});
         }
    }
