    Microsoft.Office.Interop.Word.Application wordApp = null;
    try
    {
         wordApp =(Microsoft.Office.Interop.Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
    }
    catch
    {
        // Handle exceptions here or ignore the error, your choice
        MessageBox.Show("Could not find an existing instance of Word");
    }
    // READ THIS CAREFULLY
    // If you didn't already get an instance of Word then create one
    // I don't understand why you would do this as it would have 0 documents
    if (wordApp == null)
    {
        // I would not do this part, if you create a new instance you'll have 0 documents
        wordApp = new Microsoft.Office.Interop.Word.Application();
    }
    // Rest of your code goes here...
