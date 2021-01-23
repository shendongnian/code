    using Word = Microsoft.Office.Interop.Word;
    public static Boolean CheckWordDocumentForString(String documentLocation, String stringToSearchFor, Boolean caseSensitive = true)
    {
        // Create an application object if the passed in object is null
        Word.Application winword = new Word.Application();
        // Use the application object to open our word document in ReadOnly mode
        Word.Document wordDoc = winword.Documents.Open(documentLocation, ReadOnly: true);
        // Search for our string in the document
        Boolean result;
        if (caseSensitive)
            result = wordDoc.Content.Text.IndexOf(stringToSearchFor) >= 0;
        else
            result = wordDoc.Content.Text.IndexOf(stringToSearchFor, StringComparison.CurrentCultureIgnoreCase) >= 0;
            
        // Close the document and the application since we're done searching
        wordDoc.Close();
        winword.Quit();
        return result;
    }
