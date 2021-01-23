     public class pdfPage : iTextSharp.text.pdf.PdfPageEventHelper
     {
        private long OrderId;
        private string PhoneNumber;
         //constructor
         public InvoicePdfEvents(long orderId, string phoneNumber)
        {
            OrderId = orderId;
            PhoneNumber= phoneNumber;
        }
        public override void OnEndPage(PdfWriter writer, Document doc)
        {
             //Now you can use values
             //OrderId  And PhoneNumber
            //...
        }
    }
    public class CreatePDF
    {
      private void GenerateCreatePDF(OrderListingInfo orderDetail, string contain)
      {
       var doc = new Document(PageSize.A4, 10, 10, 170, 10);
        pdfPage page = new pdfPage();
        PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream( 
        "test.pdf", FileMode.Create));
        int orderID=123456789;
        string phoneNumber="+01 123456789"
        pdfWriter.PageEvent = page.OnEndPage(pdfWriter, doc, orderID,phoneNumber);
      }
    }
