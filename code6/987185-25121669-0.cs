    void GetFilePathWithOutExtention(string path)
    {
        string[] paths = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
        foreach(var path in paths)
         {
             string pathToWrite = Path.GetFileNameWithoutExtension(path);
             if(pathToWrite != null && pathToWrite.lenght >2 )
               Console.WriteLine(pathToWrite.Substring(2,pathToWrite.lenght);
         }
    }
