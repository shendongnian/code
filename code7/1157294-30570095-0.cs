       private static IList<FileInfo> getNonHiddenFiles(DirectoryInfo baseDirectory)
        {
            var fileInfos = new List<System.IO.FileInfo>();
            fileInfos.AddRange(baseDirectory.GetFiles("*.*", SearchOption.TopDirectoryOnly).Where(w => (w.Attributes & FileAttributes.Hidden) == 0));
            foreach (var directory in baseDirectory.GetDirectories("*.*", SearchOption.TopDirectoryOnly).Where(w => (w.Attributes & FileAttributes.Hidden) == 0))
                fileInfos.AddRange(getNonHiddenFiles(directory));
            return fileInfos;
        }
