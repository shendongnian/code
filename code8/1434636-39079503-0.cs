    namespace MassFileMoverConsole
    {
        class Program
        {
            string _sourcePath;
            string _targetPath;
    
            static void Main(string[] args)
            {
                Program massMover = new Program();
                massMover.MoveThemAll();
            }
    
            void MoveThemAll()
            {
                Console.WriteLine("Enter source path : ");
                _sourcePath  = Console.ReadLine();
                Console.WriteLine("Enter target path : ");
                _targetPath = Console.ReadLine();
                
                var subFolderNamesTargetPath = Directory.GetDirectories(_sourcePath);
                foreach(var subFolderName in subFolderNamesTargetPath)
                {
                    var subFolder = new DirectoryInfo(subFolderName);
                    var subFolderFiles = subFolder.GetFiles();
                    foreach(var subFolderFile in subFolderFiles)
                    {
                        var fileNewName = subFolder.Name + "_" + subFolderFile.Name;
                        subFolderFile.CopyTo(Path.Combine(_targetPath, fileNewName));
                    }
                }
    
            }
        }
    }
