    if ( filePaths.Length > 0 )
    {
       for (int i = 0; i < filePaths.Length; ++i)
       {
          string path = filePaths[i];
          Console.WriteLine("File: " + System.IO.Path.GetFileName(path));
          Console.WriteLine();
       }
     }
     else{
       Console.WriteLine();
       Console.WriteLine(" Directory is Empty!");
       Console.WriteLine();
       Console.ReadLine();
     }
