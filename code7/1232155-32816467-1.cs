    using System;
    using Microsoft.Office.Interop.Word;
    
    class Program
    {
        static void Main()
        {
    	// Open a doc file.
    	Application application = new Application();
    	Document document = application.Documents.Open("C:\\word.doc");
    
    	//Do whatever you want
    	// Close word.
    	application.Quit();
        }
    }
