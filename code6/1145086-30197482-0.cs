    byte[] byteArray = File.ReadAllBytes("C:\\temp\\sa123.potx");
    using (MemoryStream stream = new MemoryStream())
    {
        stream.Write(byteArray, 0, (int)byteArray.Length);
        using (PresentationDocument presentationDoc = PresentationDocument.Open(stream, true))
        {
           // Change from template type to presentation type
           presentationDoc.ChangeDocumentType(PresentationDocumentType.Presentation);
        }
        File.WriteAllBytes("C:\\temp\\sa123.pptx", stream.ToArray()); 
    }
