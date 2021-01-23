    System.IO.DirectoryInfo di = new DirectoryInfo(path);
    foreach (FileInfo file in di.GetFiles())
    {
         try
         {
             file.Delete(); 
         }
         catch(System.IO.IOException)
         {
           Console.WriteLine("Please Close the following File {0}", file.Name);
           continue;
         }
    }
