    public static void Main()
    {
         string workPath = @"C:\Users\acars\Desktop\B";
         foreach (string file in Directory.EnumerateFiles(workPath)
         {
             string[] temp = file.Split('-');
             if(temp.Length > 1)
             {
                 string newName = Path.Combine(workPath, temp[1]);
                 if(!File.Exists(newName))
                    File.Move(file, newName);
             }
         }
     }
