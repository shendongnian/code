    byte[] byteArray = File.ReadAllBytes(@"C:\WorkSpace\test\WordTest.docx");
    using (var stream = new MemoryStream())
    {
       stream.Write(byteArray, 0, byteArray.Length);
       using (WordprocessingDocument doc = WordprocessingDocument.Open(stream, true))
       {
           //Logic here
       }
       using (FileStream fs = new FileStream(@"C:\WorkSpace\test\WordTest_modified.docx", 
              FileMode.Create))
       {
          stream.WriteTo(fs);
       }
    }
