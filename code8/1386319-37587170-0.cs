    using Syncfusion.DocIO.DLS;
    using Syncfusion.DocIO;
    namespace DocIO_HyperlinkinkToBookmark
    {
       class Program
       {
           static void Main(string[] args)
           {
               using (WordDocument document = new WordDocument())
               {
                   document.EnsureMinimal();
                   IWSection section = document.LastSection;
                   IWParagraph paragraph = document.LastParagraph;
                   //add text enclosed by BookmarkStart and BookmarkEnd into a paragraph
                   paragraph.AppendBookmarkStart("Title1Mark");
                   paragraph.AppendText("Title paragraph");
                   paragraph.AppendBookmarkEnd("Title1Mark");
                   //Add few paragraph of textual data
                   for (int i = 0; i < 10; i++)
                       section.AddParagraph().AppendText("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.");
                   paragraph = section.AddParagraph();
                   //Add a hyperlink with the specified display text and targets to Bookmark named "Title1Mark"
                   paragraph.AppendHyperlink("Title1Mark", "Link to Title", HyperlinkType.Bookmark);
                   document.Save("output.docx", FormatType.Docx);
               }
           }
        }
    }
