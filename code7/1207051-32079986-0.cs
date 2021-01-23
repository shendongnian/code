    class Class1
    {
         public void UploadFile()
         {
              var v = class2.GetByteStream();
    
              //rest of code here
         }
    }
    
    class Class2
    {
         public byte[] GetByteStream()
         {
              using (MemoryStream ms = new MemoryStream())
              {
                   //some code here
                   return ms.ToArray();
              }
         }     
    }
