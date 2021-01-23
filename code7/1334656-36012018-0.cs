    static void Main(string[] args)
            {
                Console.WriteLine("Takes a folder of .cs files and flattens and compacts them into a .zip." +
                              "Arg 1 : Source Folder to be resursively searched" +
                              "Arg 2 : Destination zip file" +
                              "Arg 3 : Semicolon List of folders to ignore");
    
                if (args[0] == null || args[1] == null)
                {
                    Console.Write("Args 1 or 2 missing");
                    return;
                };
    
                string SourcePath = args[0];
                string ZipDestination = args[1];
    
                List<String> ignoreFolders = new List<string>();
                if (args[2] != null)
                {
                    ignoreFolders = args[2].Split(';').ToList();
                }
    
                var files = DirSearch(SourcePath, "*.cs", ignoreFolders);
                Console.WriteLine($"{files.Count} files found to zip");
    
                if (File.Exists(ZipDestination))
                {
                    Console.WriteLine("Destination exists. Deleting zip file first");
                    File.Delete(ZipDestination);
                }
    
                int zippedCount = 0;
                using (FileStream zipToOpen = new FileStream(ZipDestination, FileMode.OpenOrCreate))
                {
                    using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                    {
                        foreach (var filePath in files)
                        {
                            Console.WriteLine($"Writing {Path.GetFileName(filePath)} to zip {Path.GetFileName(ZipDestination)}");
                            archive.CreateEntryFromFile(filePath, Path.GetFileName(filePath));
                            zippedCount++;
                        }   
                    }
                }
                Console.WriteLine($"Zipped {zippedCount} files;");
            }
    
            static List<String> DirSearch(string sDir, string filePattern, List<String> excludeDirectories)
            {
                List<String> filePaths = new List<string>();
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    if (excludeDirectories.Any(ed => ed.ToLower() == d.ToLower()))
                    {
                        continue;
                    }
    
                    foreach (string f in Directory.GetFiles(d, filePattern))
                    {
                        filePaths.Add(f);
                    }
                    filePaths.AddRange(DirSearch(d, filePattern, excludeDirectories));
                }
    
                return filePaths;
            }
