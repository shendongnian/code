    public class RazorPdf
    {
        public static byte[] GeneratePdf(string html,
            System.Collections.Generic.List<PdfPageContent> headerAndFooterContent = null)
        {
            Byte[] bytes;
            using (var ms = new MemoryStream())
            {
                using (var doc = new Document(PageSize.A4, 40f, 40f, 30f, 50f))
                {
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {
                        doc.Open();
                        var example_css = @".headline{font-size:200%}"; //incase you want to parse css
                        writer.PageEvent = new PageEventHelper(headerAndFooterContent);
                        using (var msCss = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_css)))
                        {
                            using (var msHtml = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(html)))
                            {
                                iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msHtml, msCss);
                            }
                        }
                        doc.Close();
                    }
                }
                bytes = ms.ToArray();
            }
            return bytes;
        }
    }
    public class PageEventHelper : PdfPageEventHelper
    {
        private PdfContentByte _cb;
        private PdfTemplate _template;
        private readonly System.Collections.Generic.List<PdfPageContent> _content = null;
        public PageEventHelper(System.Collections.Generic.List<PdfPageContent> content)
        {
            _content = content;
        }
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            _cb = writer.DirectContent;
            _template = _cb.CreateTemplate(50, 50);
        }
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            /* Contents */
            if (_content != null)
            {
                foreach (PdfPageContent ppc in _content)
                {
                    ColumnText ct = new ColumnText(GetCb(writer));
                    Phrase phrase = new Phrase(new Chunk(ppc.Content, FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.NORMAL)));
                    switch (ppc.Location)
                    {
                        case PdfPageLocation.Header:
                            ct.SetSimpleColumn(phrase, 40, 700, 530, 840, 25, ppc.Alignment);
                            break;
                        case PdfPageLocation.Footer:
                            ct.SetSimpleColumn(phrase, 40, 100, 530, 20, 25, ppc.Alignment);
                            break;
                    }
                    ct.Go();
                }
            }
            /* Page number */
            string text = writer.PageNumber.ToString();
            BaseFont font = BaseFont.CreateFont();
            float len = font.GetWidthPoint(text, 12);
            Rectangle pageSize = document.PageSize;
            GetCb(writer).SetRGBColorFill(100, 100, 100);
            GetCb(writer).BeginText();
            GetCb(writer).SetFontAndSize(font, 12);
            GetCb(writer).SetTextMatrix(document.RightMargin, pageSize.GetBottom(document.BottomMargin));
            GetCb(writer).ShowText(text);
            GetCb(writer).EndText();
            GetCb(writer).AddTemplate(GetTemplate(writer), document.RightMargin - len, 0);
        }
        private PdfContentByte GetCb(PdfWriter writer)
        {
            return _cb ?? (_cb = writer.DirectContent);
        }
        private PdfTemplate GetTemplate(PdfWriter writer)
        {
            return _template ?? (_template = GetCb(writer).CreateTemplate(50, 50));
        }
    }
    public class PdfPageContent
    {
        public PdfPageLocation Location { get; set; }
        public int Alignment { get; set; }
        public string Content { get; set; }
    }
    public enum PdfPageLocation
    {
        Footer = 1,
        Header = 2
    }
