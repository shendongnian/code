    string strFilePath = @"D:\Maraj\Work\Ajax.txt";
    FileStream objFS = new FileStream(strFilePath, FileMode.Open);
    List<string> list = new List<string>();
    using (StreamReader Sr = new StreamReader(objFS))
      {
        while (Sr.ReadLine() != null)
        {
        string line = Sr.ReadLine();
        if(line.Contains("Message=")
          {
            list.Add(line .Split('=')[1]);
          }
        }
         objFS.Close();
      }
