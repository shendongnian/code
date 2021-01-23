    byte[] byteArray = File.ReadAllBytes(@"C:\WorkSpace\test\WordVBATest\WordVBATest\bin\Debug\WordVBATest.docx");
    using (var stream = new MemoryStream())
    {
       stream.Write(byteArray, 0, byteArray.Length);
       using (WordprocessingDocument doc = WordprocessingDocument.Open(stream, true))
       {
           //Logic here
       }
       using (FileStream fs = new FileStream(@"C:\WorkSpace\test\WordVBATest\WordVBATest\bin\Debug\WordVBATest_modified.docx", FileMode.Create))
       {
          stream.WriteTo(fs);
       }
