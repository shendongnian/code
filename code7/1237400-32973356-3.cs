    var stack = new Stack<FileSystemInfo>(deleteableEntries); // "recursive", stack to delete deepest folders first
    while (stack.Count > 0)
    {
        FileSystemInfo fsi = stack.Peek();  // don't remove yet, only if it was deleted
        bool isDirectory = (fsi.Attributes & FileAttributes.Directory) == FileAttributes.Directory;
        fsi.Attributes = FileAttributes.Normal; // can avoid possible access-denied exceptions if it's readonly
        try
        {
            bool canBeDeleted = !isDirectory;
            if (isDirectory)
            {
                var subEntries = new DirectoryInfo(fsi.FullName).EnumerateFileSystemInfos("*.*", SearchOption.AllDirectories);
                canBeDeleted = !subEntries.Any();
                foreach (FileSystemInfo subEntry in subEntries)
                    stack.Push(subEntry);
            }
            if (canBeDeleted)
            {
                fsi.Delete();
                stack.Pop(); // remove it
            }
        } catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
        }
    }
