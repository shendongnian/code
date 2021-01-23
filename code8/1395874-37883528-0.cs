    static private void parseTheFile(string thePath)
    {
         Console.WriteLine("Attempting to parse " + System.IO.Path.GetFileName(thePath));
         string fileText;
         try
         {
            fileText = GetTextFromPdf(thePath);
         }
         catch (Exception ex)
         {
             Console.WriteLine("An error was encountered when trying to parse the file. " + ex.Message);
            getInput(); // <---- WHOOPS!
             return;
          }...
