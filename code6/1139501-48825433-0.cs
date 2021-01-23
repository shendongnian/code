    public static void Move(string source, string target)
        {
            if (!Directory.Exists(source))
            {
                throw new System.IO.DirectoryNotFoundException("Source directory couldn't be found.");
            }
            if (Directory.Exists(target))
            {
                throw new System.IO.IOException("Target directory already exists.");
            }
            DirectoryInfo sourceInfo = Directory.CreateDirectory(source);
            DirectoryInfo targetInfo = Directory.CreateDirectory(target);
            if (sourceInfo.FullName == targetInfo.FullName)
            {
                throw new System.IO.IOException("Source and target directories are the same.");
            }
            Stack<DirectoryInfo> sourceDirectories = new Stack<DirectoryInfo>();
            sourceDirectories.Push(sourceInfo);
            Stack<DirectoryInfo> targetDirectories = new Stack<DirectoryInfo>();
            targetDirectories.Push(targetInfo);
            while (sourceDirectories.Count > 0)
            {
                DirectoryInfo sourceDirectory = sourceDirectories.Pop();
                DirectoryInfo targetDirectory = targetDirectories.Pop();
                foreach (FileInfo file in sourceDirectory.GetFiles())
                {
                    file.CopyTo(Path.Combine(targetDirectory.FullName, file.Name), overwrite: true);
                }
                foreach(DirectoryInfo subDirectory in sourceDirectory.GetDirectories())
                {
                    sourceDirectories.Push(subDirectory);
                    targetDirectories.Push(targetDirectory.CreateSubdirectory(subDirectory.Name));
                }
            }
            sourceInfo.Delete(true);
        }
