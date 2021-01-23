    public static void MoveFilesAndFolders(string sourcePath, string destinationPath)
    {
            var directories = Directory.GetDirectories(sourcePath);
            var currentDestinationPath = destinationPath;
            foreach (var directory in directories)
            {
                var subDirectory = new DirectoryInfo(directory);
                //Create sub directory in the destination folder if the business rules is satisfied
                if (DateTime.Today.Subtract(File.GetCreationTime(directory)).Days < 5)
                {
                    var newDestinationDirectory = Directory.CreateDirectory(Path.Combine(currentDestinationPath, subDirectory.Name));
                    MoveFilesAndFolders(subDirectory.FullName, newDestinationDirectory.FullName);
                }
            }
            foreach (var file in Directory.GetFiles(sourcePath))
            {
                var fileName = Path.GetFileName(file);
                //Copy the file to destination folder if the business rule is satisfied
                if (!string.IsNullOrEmpty(fileName))
                {
                    var newFilePath = Path.Combine(destinationPath, fileName);
                    if (!File.Exists(newFilePath) && (DateTime.Today.Subtract(File.GetCreationTime(file)).Days < 5)))
                    {
                        File.Move(file, newFilePath);
                    }
                }
            }
    }
