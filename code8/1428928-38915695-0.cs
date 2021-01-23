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
                            System.IO.DirectoryInfo rootDir = new DirectoryInfo(pdxPathDocFiles);
                            db.Database.ExecuteSqlCommand("TRUNCATE TABLE [FileDBRecord]");
                            db.SaveChanges();
                            db.Dispose();
                            Console.WriteLine("Remove data from table");
                            WalkDirectoryTree(rootDir, rootDir.ToString());
                            Console.WriteLine("All ok");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                Console.WriteLine("Bye, Good Day.");
                Console.WriteLine("Processing complete. Press any key to exit.");
                Console.ReadKey();
            }
            static void WalkDirectoryTree(System.IO.DirectoryInfo root, string rootDir)
            {
                //Console.WriteLine("Go to folder: "+  root.FullName.Replace(rootDir, ""));
                System.IO.FileInfo[] files = null;
                System.IO.DirectoryInfo[] subDirs = null;
                try
                {
                    files = root.GetFiles("*.*");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                if (files != null)
                {
                    PayDox_EPD19_T20_RGMEntities db = new PayDox_EPD19_T20_RGMEntities();
                    foreach (var currentElement in files)
                    {
                        db.FileDBRecord.Add(new FileDBRecord { FileName = currentElement.FullName.Replace(rootDir, ""), FileSize = currentElement.Length });
                    }
                   
                    db.SaveChanges();
                    db.Dispose();
                    subDirs = root.GetDirectories();
                    Parallel.ForEach(subDirs,
                    currentElement =>
                    {
                        try
                        {
                            WalkDirectoryTree(currentElement, rootDir);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    });
                }
            }
        }
