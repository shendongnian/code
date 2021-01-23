    reader = new PdfReader(fileOut);
    Document final = new Document(reader.GetPageSize(1));
    PdfWriter w = PdfWriter.GetInstance(final, new FileStream(finalFile, FileMode.Create, FileAccess.Write));
    w.SetFullCompression();
    final.Open();
    for (int i = 1; i <= reader.NumberOfPages; i++)
    {
        final.NewPage();
        PdfContentByte cb = w.DirectContent;
        ControlNumberTimes(cb, "C"+i, 560, 725, 270, Element.ALIGN_LEFT);
        cb.AddTemplate(w.GetImportedPage(reader, i), 0, 0);
    }
    final.Close();
