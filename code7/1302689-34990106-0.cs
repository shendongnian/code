    // Create Word object
    Word._Application wordApp = null;
    // Try and get an existing instance
    try
    {
        wordApp = (Word._Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
    }
    catch { /* Ignore error */ }
    // Check if we got an instance, if not then create one
    if (wordApp == null)
    {
        wordApp = new Microsoft.Office.Interop.Word.Application();
    }
    //Now you can use wordApp
    ... wordApp.Documents.Open(...);
