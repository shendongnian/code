    using MigraDoc.DocumentObjectModel;
    using MigraDoc.RtfRendering;
    using Spire.Doc;
    using System.IO;
    namespace MigraDocTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var stream = new MemoryStream())
                {
                    // Generate RTF (using MigraDoc)
                    var migraDoc = new MigraDoc.DocumentObjectModel.Document();
                    var section = migraDoc.AddSection();
                    var paragraph = section.AddParagraph();
                    paragraph.AddFormattedText("Hello World!", TextFormat.Bold);
                    var rtfDocumentRenderer = new RtfDocumentRenderer();
                    rtfDocumentRenderer.Render(migraDoc, stream, false, null);
                    // Convert RTF to DOCX (using Spire.Doc)
                    var spireDoc = new Spire.Doc.Document();
                    spireDoc.LoadFromStream(stream, FileFormat.Auto);
                    spireDoc.SaveToFile("D:\\example.docx", FileFormat.Docx );
                }
            }
        }
    }
