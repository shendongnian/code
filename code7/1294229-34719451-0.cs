    private string CalculateChecksum(string textFileText) 
    { 
       using (var md5 = MD5.Create()) 
       {
          return BitConverter.ToString(md5.ComputeHash(File.ReadAllBytes(textFileText))).Replace("-", "");
       }
    }
