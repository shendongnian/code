    public IList<PdfText> GetTexts()
    {
        List<PdfText> result = GetList().Where(x => x is PdfText).ToList();
        return result;
    }
