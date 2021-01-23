    public void MergeDocument()
    {
        //Initialize the SDK library
        //You have to call this function before you can call any PDF processing functions.
        PdfCommon.Initialize();
    
        //Open and load a PDF document in which will be merged other files
        using (var mainDoc = PdfDocument.Load(@"c:\test001.pdf"))
        {
            //Open one PDF document.
            using (var doc = PdfDocument.Load(@"c:\doc1.pdf"))
            {
                //Import all pages from document
                mainDoc.Pages.ImportPages(
                    doc,
                    string.Format("1-{0}", doc.Pages.Count),
                    mainDoc.Pages.Count
                    );
            }
    
            //Open another PDF document.
            using (var doc = PdfDocument.Load(@"c:\doc2.pdf"))
            {
                //Import all pages from document
                mainDoc.Pages.ImportPages(
                    doc,
                    string.Format("1-{0}", doc.Pages.Count),
                    mainDoc.Pages.Count
                    );
            }
    
            mainDoc.Save(@"c:\ResultDocument.pdf", SaveFlags.NoIncremental);
    
    
        }
        //Release all resources allocated by the SDK library
        PdfCommon.Release();
    }
