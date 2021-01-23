    public class ITextSharpExtension
    {
    //Add pagination
    public class PageEventHelper : PdfPageEventHelper
    {
        PdfContentByte cb;
        PdfTemplate template;
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            cb = writer.DirectContent;
            template = cb.CreateTemplate(50, 50);
        }
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            Font arial = FontFactory.GetFont("Arial", 10, GrayColor.GRAY);
            base.OnEndPage(writer, document);
            int pageN = writer.PageNumber;
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            string text = String.Format("Page {0} of ", pageN.ToString());
            float len = bf.GetWidthPoint(text, 8);
            iTextSharp.text.Rectangle pageSize = document.PageSize;
            cb.SetRGBColorFill(100, 100, 100);
            cb.BeginText();
            cb.SetFontAndSize(bf, 10);
            cb.SetTextMatrix(10, pageSize.GetBottom(10));
            cb.ShowText(text);
            cb.EndText();
            cb.AddTemplate(template, 60, pageSize.GetBottom(10));
        }
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            template.BeginText();
            template.SetFontAndSize(bf, 10);
            template.SetTextMatrix(0, 0);
            template.ShowText("" + (writer.PageNumber - 1));
            template.EndText();
        }
    }
