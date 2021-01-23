    static void Main(string[] args)
    {
        string pdxPathDocFiles = System.Configuration.ConfigurationManager.AppSettings["PDX_PathDocFiles"] as string;
        if (string.IsNullOrEmpty(pdxPathDocFiles))
        {
            Console.WriteLine("In the configuration file is missing the path to the root directory - PDX_PathDocFiles.");
        }
        else
        {
            if (!Directory.Exists(pdxPathDocFiles))
            {
                Console.WriteLine("Directory not found");
            }
            else
            {
                try
                {
                    Console.WriteLine("rootPath: " + pdxPathDocFiles);
                    PayDox_EPD19_T20_RGMEntities db = new PayDox_EPD19_T20_RGMEntities();
                    db.FileDBRecord.RemoveRange(db.FileDBRecord);
                    db.SaveChanges();
                    Console.WriteLine("Remove data from table");
                    IList<FileDBRecord> files = null;
                    System.IO.DirectoryInfo rootDir2 = new DirectoryInfo(pdxPathDocFiles);
                    try
                    {
                        files = rootDir2.GetFiles("*.*", SearchOption.AllDirectories).Select(x => new FileDBRecord { FileName = x.FullName.Replace(pdxPathDocFiles, ""), FileSize = x.Length });
                        Console.WriteLine("Reed {0} fileName", files.Length);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine("You do not have permission to access one or more folders in this directory tree.");
                        Console.WriteLine(ex.Message);
                        return;
                    }
                    files.Foreach(db.FileDBRecord);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("All ok");
            }
        }
        Console.WriteLine("Bye, Good Day.");
    }
