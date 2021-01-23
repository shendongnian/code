    public string PdfToString(string fileName)
    {
        var sb = new StringBuilder();    
        var reader = new PdfReader(fileName);
        for (int page = 1; page <= reader.NumberOfPages; page++)
        {
    	    var strategy = new SimpleTextExtractionStrategy();
            string text = PdfTextExtractor.GetTextFromPage(reader, page, strategy);
    		text = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(text)));
            sb.Append(currentText);
        }
        pdfReader.Close();        
        return text.ToString();
    }
