    public void Save(string fileName)
    {
      var contents = "Hello World!";        
      System.IO.File.WriteAllText(@"C:\Users\barry\Desktop\GG\pewpew\receipt.txt", contents);
    }
