    try{
        string extractPath = @"C:\Documents";
        string ExtractedPDF ="";
        using(ZipArchivev zip = ZipFile.Open(zipFP, ZipArchiveMode.Read))
            foreach(ZipArchiveEntry entry in zip.Entries){
                try{
                    ExtractedPDF= Path.Combine(extractPath, entry.FullName);
                    entry.ExtractToFile(ExtractedPDF,true);
                    
                }catch(System.IOException){
                    Console.WriteLine("error during extraction...");
                }
            } 
            if( System.IO.File.Exists(ExtractedPDF))
            {
                 PdfPanel.OpenFile(ExtractedPDF);
            }
    }catch(AccessViolationException ex){
        Console.WriteLine("Can't display a zip in the PDF panel..." + ex.InnerException);
    }
