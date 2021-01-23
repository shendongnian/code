    var dir = Directory.GetDirectories(dirpath);
    dir.Add("another path");
    foreach (string d in dir)
     {
         foreach (string f in Directory.GetFiles(d))
         {
            Console.WriteLine(f);
            File.Copy(f,"");
         }
     }
