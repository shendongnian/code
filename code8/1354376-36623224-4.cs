    byte[] byteArray = File.ReadAllBytes(@"C:\...\Template.dotx");
    using (var stream = new MemoryStream())
    {
        stream.Write(byteArray, 0, byteArray.Length);
        using (WordprocessingDocument doc = WordprocessingDocument.Open(stream, true))
        {
           //Needed because I'm working with template dotx file, 
           //remove this if the template is a normal docx. 
            doc.ChangeDocumentType(DocumentFormat.OpenXml.WordprocessingDocumentType.Document);
            doc.InsertText("contentControlName","testtesttesttest");
        }
        using (FileStream fs = new FileStream(@"C:\...\newFile.docx", FileMode.Create))
        {
           stream.WriteTo(fs);
        }
    }
