    public static string CheckFileName(string name)
    {
         if(string.IsNullOrEmpty(name))
              throw new ArgumentNullException();
         int i = 0;
         string file = Path.Combine(ConfigurationManager.AppSettings[@"FolderPath"], name);
         while(File.Exist(file))
               file = String.Format(file-{0}, i++);
         return file;
    }
