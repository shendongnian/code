    public static byte[] PdfForHtml(string html)
    {
        // Create ABCpdf Doc object
        var doc = new Doc();
        // Add passed in HTML to ABCpdf Doc object
        int theID = doc.AddImageHtml(html);
        // Loop through document to create, potentially, multi-page PDF
        while (true)
        {
            if (!doc.Chainable(theID))
            {
                break;
            }
            doc.Page = doc.AddPage();
            theID = doc.AddImageToChain(theID);
        }
        // Flatten the PDF
        for (int i = 1; i <= doc.PageCount; i++)
        {
            doc.PageNumber = i;
            doc.Flatten();
        }
        // Get PDF as byte array to eventually pass back 
        // in controller action method
        var pdfbytes = doc.GetData();
        doc.Clear();
        return pdfbytes;
    }
