    public string PdfToString(string fileName)
    {
        var sb = new StringBuilder();    
        var reader = new PdfReader(fileName);
        for (int page = 1; page <= reader.NumberOfPages; page++)
        {
    	    var strategy = new SimpleTextExtractionStrategy();
            string text = PdfTextExtractor.GetTextFromPage(reader, page, strategy);
    		text = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(text)));
            sb.Append(text);
        }
        reader.Close();        
        return sb.ToString();
    }
    //adjust expression as needed
    Regex emailRegex = new Regex("Email Address (?<email>.+?) Passport No");
    public IEnumerable<string> ExtractEmails(string content)
    {	
    	var matches = emailRegex.Matches(content);
    	foreach (Match m in matches)
    	{
    		yield return m.Groups["email"].Value;
    	}
    }
