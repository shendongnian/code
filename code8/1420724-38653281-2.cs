    public string GetText(string filePath)
    {
        string fileContents;
        // read the file if it exists
        if (File.Exists(filePath))
            fileContents = File.ReadAllText(filePath);
        else
            return null;
        // Find the place where the text content begins
        int textStart = fileContents.IndexOf("<Text>") + 6 + Environment.NewLine.Length; // The length on newLine is neccecary because the line shift after "<Text>" shall NOT be included in the text content
        // Find the place where the text content ends
        int textEnd = fileContents.LastIndexOf("</Text>");
        return fileContents.Substring(textStart, textEnd - textStart - Environment.NewLine.Length); // The length again to NOT include a line shift added earlier by code
    }
