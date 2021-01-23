    using Syncfusion.DocIO.DLS;
    using Syncfusion.DocIO;
    using System.IO;
    namespace DocIO_MergeDocument
    {
    class Program
    {
        static void Main(string[] args)
        {
           //Creates a new Word document
            WordDocument document = new WordDocument(@"InputDocument.docx");
            //Update the words count in the document.
            document.UpdateWordCount(false);
            //Get the updated words count
            int wordCount = document.BuiltinDocumentProperties.WordCount;
            //Releases the resources occupied by WordDocument instance
            document.Dispose();
        }
    }    
    }
