    [UseNetDataContractSerializer]
    public class PdfPrinterService : IPdfPrinter
    {
       public PdfPrinterResponse Print(PdfPrinterRequest request)
       {
         return PdfPrinterFacade.PrintPdf(request);
       }
    }
    [MessageContract]
    public class PdfPrinterRequest
    {
        [MessageBodyMember]
        public object Document { get; set; }
    }
