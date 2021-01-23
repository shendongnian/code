    public IList<PdfText> GetTexts()
    {
        List<PdfText> result = new List<PdfText>();
        List<PdfObject> list = GetList();
        foreach(var item in list)
        {
            if(item is PdfText) result.Add(item)
        }
        return result;
    } 
