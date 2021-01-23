    public static string[] GetFileList(string Directory,string extensions)
       {
           string[] extensionlist = extensions.Split(';');
           List<string> FileList = new List<string>();
           foreach (string extension in extensionlist)
           {
               FileList.AddRange(System.IO.Directory.GetFiles(Directory, "*." + extension, System.IO.SearchOption.AllDirectories)); 
           }
           return FileList.ToArray();
       }
