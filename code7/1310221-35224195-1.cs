    Microsoft.Office.Interop.Word.Application wordApp = null;
    try
    {
         wordApp =(Microsoft.Office.Interop.Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
    }
    catch
    {
        // Handle exceptions here or ignore the error, your choice
    }
    // If you didn't already get an instance of Word then create one
    // I don't understand why you would do this as it would have 0 documents
    if (wordApp == null)
    {
        wordApp = new Microsoft.Office.Interop.Word.Application();
    }
    // Rest of your code goes here...
