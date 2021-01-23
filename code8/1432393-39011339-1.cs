    public bool KeywordExists(string keyWord)
    {
        using (PdfReader reader = new PdfReader(pdfPath))
        {
            StringBuilder strText = new StringBuilder();    
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                strText.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                if(strText.Contains(keyWord)) return true;
            }
            return false;
         }
    }
