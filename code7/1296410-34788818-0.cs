    byte[] form
    using (var msOutput = new MemoryStream())
    {
        iTextSharp.text.Document doc = new iTextSharp.text.Document();
        byte[] byteArray = Convert.FromBase64String("someString");
        
        PdfCopy copy = new PdfCopy(doc, msOutput);
        
        copy.SetMergeFields();
        
        doc.Open();
        
        PdfReader reader = new PdfReader(byteArray);
        
        copy.AddDocument(reader);
        
        reader.Close();
        copy.Close();
        
        doc.Close(); 
        
        form = msOutput.ToArray();
    }
