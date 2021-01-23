    public class ITextEvents : PdfPageEventHelper
    {
        public string headervalue = "";
        
        public override void OnEndPage(PdfWriter writer, Document document)
        {
           [..your implementation..]
        }
     }
