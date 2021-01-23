    byte[] all;
    
    using (MemoryStream ms = new MemoryStream())
    {
      Document doc = new Document();
      PdfCopy copy = new PdfCopy(doc, ms);
      copy.SetMergeFields();
    
      doc.Open();
      foreach (PdfReader pdf in pdfs)
           copy.AddDocument(pdf);
    
      doc.Close();
    
      all = ms.ToArray();
    }
    
    Output = new PdfStamper(new PdfReader(all), outStream);
    Output.AcroFields.GenerateAppearances = true;
