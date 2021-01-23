    private void ReportHighlightPDFAnnotation(string highLightFile, int pageno)
    {
        PdfReader reader = new PdfReader(highLightFile);
        PdfDictionary pageDict = reader.GetPageN(pageno);
        PdfArray annots = pageDict.GetAsArray(PdfName.ANNOTS);
        if (annots != null)
        {
            for (int i = 0; i < annots.Size; ++i)
            {
                PdfDictionary annotationDic = (PdfDictionary)PdfReader.GetPdfObject(annots[i]);
                PdfName subType = (PdfName)annotationDic.Get(PdfName.SUBTYPE);
                if (subType.Equals(PdfName.HIGHLIGHT))
                {
                    Console.Write("HighLight at {0} with {1}\n", annotationDic.GetAsArray(PdfName.RECT), annotationDic.GetAsArray(PdfName.QUADPOINTS));
                }
            }
        }
    }
