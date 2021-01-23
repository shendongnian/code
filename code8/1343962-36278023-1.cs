    public class DirectoryFinder
    {
        public bool FidDirectory(string path, string folderName)
        {
            var directories = Directory.EnumerateDirectories(path);
            return directories.Any(d => d.Equals(path + folderName));
        }
    }
