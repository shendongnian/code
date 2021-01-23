    using Microsoft.VisualBasic.FileIO; //add this
    static void Main(string[] args)
    {
        string text = System.IO.File.ReadAllText(@"D://dtl.txt"); //note this
        List<string[]> param = new List<string[]>();
        string[] words; //add intermediary reference
        using (TextFieldParser parser = new TextFieldParser(new StringReader(text))) {
			parser.Delimiters = new string[] { "," }; //the parameter must be comma
			parser.HasFieldsEnclosedInQuotes = true;
			while ((words = parser.ReadFields()) != null)
				param.Add(words);
		}
        var x = param; // for debug
    }
