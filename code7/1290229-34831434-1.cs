    public class PrintService : IPrintService
    {
        public string Print(Stream wordDocStream)
        {
            // copy our stream to a local file
            var tempFile = Path.GetTempFileName();
            using(var file = File.Create(tempFile))
            {
                wordDocStream.CopyTo(file);
            }
    
            // start word
            var wordApp = new Microsoft.Office.Interop.Word.Application();
            // setup printer
            wordApp.ActivePrinter = "Canon LBP3010/LBP3018/LBP3050";
            // open, collect data, print and close
            var doc = wordApp.Documents.Open(tempFile);
            doc.PrintOut();
            var res = doc.Words.Count;
            doc.Close(false);
    
            // quit word
            wordApp.Quit(false);
            // delete temp file
            File.Delete(tempFile);
            return String.Format("{0} words", res);
        }
    }
