    PdfReader reader = new PdfReader(outputFile);
    using (FileStream fs = new FileStream(secondFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
        using (PdfStamper stamper = new PdfStamper(reader, fs)) {
            int PageCount = reader.NumberOfPages;
            for (int i = 1; i <= PageCount; i++) {
                ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_CENTER, new Phrase(String.Format("Page {0} of {1}", i, PageCount)), 560, 725, 270);
            }
        }
    }
