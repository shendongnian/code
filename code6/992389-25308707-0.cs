     // Create new parser object and setup parameters
    var parser = new TextFieldParser(new StringReader(File.ReadAllText(filePath)))
    {
    	HasFieldsEnclosedInQuotes = true,
    	Delimiters = new string[] { "," },
    	TrimWhiteSpace = true
    };
    
    var csvSplitList = new List<string>();
    
    // Reads all fields on the current line of the CSV file and returns as a string array
    // Joins each field together with new delimiter "|"
    while (!parser.EndOfData)
    {
    	csvSplitList.Add(String.Join("|", parser.ReadFields()));
    }
    
    // Newline characters added to each line and flattens List<string> into single string
    var formattedCsvToSave = String.Join(Environment.NewLine, csvSplitList.Select(x => x));
    
    // Write single string to file
    File.WriteAllText(filePathFormatted, formattedCsvToSave);
    parser.Close();
