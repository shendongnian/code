    public class MyPageHeader : PdfPageEventHelper
    {
        
        PdfPTable header = ... // define header table here        
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            header.WriteSelectedRows(0, -1, document.Left, document.Top, writer.DirectContent);
        }
    }
