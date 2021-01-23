    public IList<PdfText> GetTexts()
    {
        List<PdfText> result = new List<PdfText>();
        List<PdfObject> list = GetList();
        foreach(var item in list)
        {
            var textItem = item as PdfText
            if (textItem != null) result.Add(textItem)
        }
        return result;
    } 
