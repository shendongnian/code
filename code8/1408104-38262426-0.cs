    byte[] bytes;
    using (MemoryStream ms = new MemoryStream()) 
    {
        PdfWriter outputWriter = PdfWriter.GetInstance(newPDF, ms);
        newPDF.Open();
        PdfContentByte cb1 = outputWriter.DirectContent;
    
        for (int pagesToAddFromSourcePDFToNewPDF = 0; pagesToAddFromSourcePDFToNewPDF < soa_total_pages; pagesToAddFromSourcePDFToNewPDF++)
        {
            if (pagesToAddFromSourcePDFToNewPDF > 0)
            {
                currentPageInSourcePDF++;
            }
    
            newPDF.NewPage();
            PdfImportedPage page = outputWriter.GetImportedPage(sourcePDF, currentPageInSourcePDF);
            cb1.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
        }
        newPDF.Close();
        bytes = ms.ToArray();
    }
    
    filesCreated++;
    using (var ms = new MemoryStream(bytes))
    {
        // Upload stream to AWS
        using (var transferUtility = new TransferUtility(client))
        {
            transferUtility.Upload(ms, "mybucketname", "1/soa/" + newPDFFilename);
        }
    
    }
