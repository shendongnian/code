    public IList<PdfText> GetTexts()
    {
        List<PdfText> result = GetList()
            .Where(x => x is PdfText)
            .Select(x => (PdfText)x)
            .ToList();
        return result;
    }
