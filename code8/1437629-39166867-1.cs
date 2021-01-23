    reader = new PdfReader(sourcePDFpath);
    sourceDocument = new Document(reader.GetPageSizeWithRotation(startpage));
    pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPDFpath, System.IO.FileMode.Create));
    sourceDocument.Open();
    for (int i = startpage; i <= endpage; i++)
    {
        importedPage = pdfCopyProvider.GetImportedPage(reader, i);
        pdfCopyProvider.AddPage(importedPage);
    }
    sourceDocument.Close();
    reader.Close();
