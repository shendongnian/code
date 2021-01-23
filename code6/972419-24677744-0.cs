    public class pdfPage : iTextSharp.text.pdf.PdfPageEventHelper
    {           
        public int parametro { get; set; }
        public override void OnEndPage(PdfWriter writer, Document doc)
        {
            //...
        }
    }
