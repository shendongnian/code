       using( FileStream fs = new FileStream(@"C:\Test.txt",
                          FileMode.OpenOrCreate,
                          FileAccess.Write))
       {
           StreamWriter writer = new StreamWriter(fs);
           byte[] info = new UTF8Encoding(true).GetBytes(fileContent);
           fs.Write(info, 0, info.Length);
           fs.Close();
       } 
