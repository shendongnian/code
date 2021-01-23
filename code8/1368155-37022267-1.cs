    for (int page = 1; page <= pdfReader.NumberOfPages; page++)
    {
        Console.Write("\nPage {0}\n", page);
        PdfDictionary pageDictionary = pdfReader.GetPageNRelease(page);
        PdfArray annotsArray = pageDictionary.GetAsArray(PdfName.ANNOTS);
        if (annotsArray == null || annotsArray.IsEmpty())
        {
            Console.Write("  No annotations.\n");
            continue;
        }
        foreach (PdfObject pdfObject in annotsArray)
        {
            PdfObject direct = PdfReader.GetPdfObject(pdfObject);
            if (direct.IsDictionary())
            {
                PdfDictionary annotDictionary = (PdfDictionary)direct;
                Console.Write("  SubType: {0}\n", annotDictionary.GetAsName(PdfName.SUBTYPE));
                PdfDictionary appearancesDictionary = annotDictionary.GetAsDict(PdfName.AP);
                if (appearancesDictionary == null)
                {
                    Console.Write("    No appearances.\n");
                    continue;
                }
                foreach (PdfName key in appearancesDictionary.Keys)
                {
                    Console.Write("    Appearance: {0}\n", key);
                    PdfStream value = appearancesDictionary.GetAsStream(key);
                    if (value != null)
                    {
                        String text = ExtractAnnotationText(value);
                        Console.Write("    Text:\n---\n{0}\n---\n", text);
                    }
                }
            }
        }
    }
