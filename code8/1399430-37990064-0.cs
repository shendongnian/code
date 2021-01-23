    // Create a new document and add a page to it
    PdfFixedDocument document = new PdfFixedDocument();
    PdfPage page = document.Pages.Add();
    
    // Create the text annotation and set its properties.
    PdfTextAnnotation ta = new PdfTextAnnotation();
    ta.Author = "John Doe";
    ta.Contents = "I am a text annotation.";
    ta.IconName = "Note";
    // Add the annotation to the page
    page.Annotations.Add(ta);
    ta.Location = new PdfPoint(50, 50);
    
    // Save the document
    // Get a local folder for the application.
    StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
    
    StorageFile pdfFile = await storageFolder.CreateFileAsync("sample.pdf", CreationCollisionOption.ReplaceExisting);
    var pdfStream = await pdfFile.OpenAsync(FileAccessMode.ReadWrite);
    
    // Convert the random access stream to a .NET Stream and save the document.
    using (Stream stm = pdfStream.AsStream())
    {
        document.Save(stm);
        await stm.FlushAsync();
    }
    pdfStream.Dispose();
    
    MessageDialog messageDialog = new MessageDialog("File(s) saved with success to application's local folder.");
    await messageDialog.ShowAsync();
