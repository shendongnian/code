    PdfReader reader = new PdfReader(pathToFile);
    int n = reader.NumberOfPages;
    int cnt;
    for (cnt = 1; cnt <= reader.NumberOfPages; cnt++)
    {
        reader = new PdfReader(pathToFile);
        reader.SelectPages(cnt.ToString());
        MemoryStream memoryStream = new MemoryStream();
        using (PdfStamper stamper = new PdfStamper(reader, memoryStream))
        {
            stamper.SetEncryption(
                null,
                Encoding.ASCII.GetBytes("password_here"),
                PdfWriter.ALLOW_PRINTING,
                PdfWriter.ENCRYPTION_AES_128);
        }
        reader.Close();
        // now do something with the memoryStream.ToArray()
    }
