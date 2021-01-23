    public static class ExcelMergeExtension
    {
        public static ExcelFile Merge(this ExcelFile destination, string sourcePath)
        {
            var sourceFileName = Path.GetFileNameWithoutExtension(sourcePath);
            var source = ExcelFile.Load(sourcePath);
    
            foreach (var sourceSheet in source.Worksheets)
                destination.Worksheets.AddCopy(
                    string.Format("{0}-{1}", sourceFileName, sourceSheet.Name),
                    sourceSheet);
    
            return destination;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var options = new PdfSaveOptions() { SelectionType = SelectionType.EntireFile };
    
            ExcelFile.Load("Book1.xlsx")
                     .Merge("Book2.xlsx")
                     .Merge("Book3.xlsx")
                     .Save("Books.pdf", options);
        }
    }
