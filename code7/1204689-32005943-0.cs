         if (ofd.ShowDialog() == DialogResult.OK) 
         {
                        using (ZipFile zip = ZipFile.OpenRead(ofd.FileName))
                        {
                            foreach (ZipEntry f in zip)
                            {
                                GetMD5HashFromFile(ofd.Open());
                            }
                        }
    
    
    public static string GetMD5HashFromFile(Stream stream) 
    { 
         using (var md5 = new MD5CryptoServiceProvider()) 
         { 
         var buffer = md5.ComputeHash(stream); 
         var sb = new StringBuilder(); 
         for (int i = 0; i < buffer.Length; i++)
         { 
         sb.Append(buffer[i].ToString("x2")); 
         } 
         return sb.ToString(); 
        } 
    }
