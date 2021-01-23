    using DSOFile;
    public static string GetAuthorFromFile(string filename)
    {
     var test = new OleDocumentProperties();
     test.Open(filename, true, DSOFile.dsoFileOpenOptions.dsoOptionDefault);
     return test.SummaryProperties.Author;
    }
