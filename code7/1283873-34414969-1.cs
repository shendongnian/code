    public class HtmlPageEventHelper : PdfPageEventHelper
    {
        public HtmlPageEventHelper(string html)
        {
            this.html = html;
        }
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            ColumnText ct = new ColumnText(writer.DirectContent);
            XMLWorkerHelper.GetInstance().ParseXHtml(new ColumnTextElementHandler(ct), new StringReader(html));
            ct.SetSimpleColumn(document.Left, document.Top, document.Right, document.GetTop(-20), 10, Element.ALIGN_MIDDLE);
            ct.Go();
        }
        string html = null;
    }
