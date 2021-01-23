    PdfReader reader = new PdfReader(srcFile);
    AcroFields.Item field = reader.AcroFields.Fields["[STOP_HERE]"];
    if (field != null)
    {
        int firstPage = reader.NumberOfPages + 1;
        for (int index = 0; index < field.Size; index++)
        {
            int page = field.GetPage(index);
            if (page > 0 && page < firstPage)
                firstPage = page;
        }
        if (firstPage <= reader.NumberOfPages)
        {
            reader.SelectPages("1-" + firstPage);
            PdfStamper stamper = new PdfStamper(reader, new FileStream(dstFile, FileMode.Create, FileAccess.Write));
            stamper.Close();
        }
    }
    reader.Close();
