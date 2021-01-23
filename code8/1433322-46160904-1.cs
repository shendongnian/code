    namespace GerarPDF
    {
    public class GerarPDF
    {
        public const String DEST = "results/example.pdf";
        public GerarPDF()
        {
            FileInfo file = new FileInfo(String.Concat(AppDomain.CurrentDomain.BaseDirectory, @"/", DEST));
            file.Directory.Create();
            this.createPdf(file.FullName);
        }
        public void createPdf(String dest)
        {
            FileStream fs = new FileStream(dest, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            Document document = new Document(PageSize.LETTER);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            TOCEvent evento = new TOCEvent();
            writer.PageEvent = evento;
            for (int i = 0; i < 10; i++)
            {
                String title = "This is title " + i;
                Chunk c = new Chunk(title, new Font());
                c.SetGenericTag(title);
                document.Add(new Paragraph(c));
                for (int j = 0; j < 50; j++)
                {
                    document.Add(new Paragraph("Line " + j + " of title " + i + " page: " + writer.PageNumber));
                }
            }
            document.NewPage();
            document.Add(new Paragraph("Table of Contents", new Font()));
            Chunk dottedLine = new Chunk(new DottedLineSeparator());
            List<PageIndex> entries = evento.getTOC();
            MultiColumnText columns = new MultiColumnText();
            columns.AddRegularColumns(72, 72 * 7.5f, 24, 2);
            Paragraph p;
            for (int i = 0; i < 10; i++)
            {
                foreach (PageIndex pageIndex in entries)
                {
                    Chunk chunk = new Chunk(pageIndex.Text);
                    chunk.SetAction(PdfAction.GotoLocalPage(pageIndex.Name, false));
                    p = new Paragraph(chunk);
                    p.Add(dottedLine);
                    chunk = new Chunk(pageIndex.Page.ToString());
                    chunk.SetAction(PdfAction.GotoLocalPage(pageIndex.Name, false));
                    p.Add(chunk);
                    columns.AddElement(p);
                }
            }
            document.Add(columns);
            document.Close();
        }
        public class TOCEvent : PdfPageEventHelper
        {
            protected int counter = 0;
            protected List<PageIndex> toc = new List<PageIndex>();
            public override void OnGenericTag(PdfWriter writer, Document document, Rectangle rect, string text)
            {
                String name = "dest" + (counter++);
                int page = writer.PageNumber;
                toc.Add(new PageIndex() { Text = text, Name = name, Page = page });
                writer.DirectContent.LocalDestination(name, new PdfDestination(PdfDestination.FITH, rect.GetTop(0)));
            }
            public List<PageIndex> getTOC()
            {
                return toc;
            }
        }
    }
    public class PageIndex
    {
        public string Text { get; set; }
        public string Name { get; set; }
        public int Page { get; set; }
    }
    }
