    using (PdfCopy copy = new PdfCopy(document, OUTPUT_STREAM)) {
        document.Open();
        PdfReader reader1 = new PdfReader(r1);
        int n1 = reader1.NumberOfPages;
        PdfImportedPage page;
        PdfCopy.PageStamp stamp;
        for (int i = 0; i < n1; ) {
            page = copy.GetImportedPage(reader1, ++i);
            stamp = copy.CreatePageStamp(page);
            // CHANGE THE PAGE,
            // e.g. by manipulating stamp.GetOverContent()
            ...
            //
            stamp.AlterContents();
            copy.AddPage(page);
        }
    }
