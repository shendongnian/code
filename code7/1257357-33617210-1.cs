    public class StandardPrintHelper : iTextSharp.text.pdf.PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_CENTER, new Phrase(writer.PageNumber.ToString()), 500, 140, 0);
        }
    }
