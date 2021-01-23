    public struct NameAndDate
         {
             public string Name;
             public DateTime Date;
             public NameAndDate(string name, DateTime date)
             {
                 Name = name;
                 Date = date;
             }
         }   
    DirectoryInfo d = new DirectoryInfo(@"C:\TestPath");
    FileInfo[] AllFiles = d.GetFiles("*.*");  // Whatever file type you want.
    
    NameAndDate[] tmp = new NameAndDate[AllFiles.Length];
    for (int i = 0; i < AllFiles.Length; i++)
        tmp[i] = new NameAndDate(AllFiles[i].Name, AllFiles[i].CreationTime);
                
    foreach(var v in tmp)
        Console.WriteLine(v.Date);
