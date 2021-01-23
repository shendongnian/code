    public static class ZipHelper {
        public static void CreateFromDirectory(
            string sourceDirectoryName
        ,   string destinationArchiveFileName
        ,   CompressionLevel compressionLevel
        ,   bool includeBaseDirectory
        ,   Encoding entryNameEncoding
        ,   Predicate<string> filter // Add this parameter
        ) {
            if (string.IsNullOrEmpty(sourceDirectoryName)) {
                throw new ArgumentNullException("sourceDirectoryName");
            }
            if (string.IsNullOrEmpty(destinationArchiveFileName)) {
                throw new ArgumentNullException("destinationArchiveFileName");
            }
            var filesToAdd = Directory.GetFiles(sourceDirectoryName, "*", SearchOption.AllDirectories);
            var entryNames = GetEntryNames(filesToAdd, sourceDirectoryName, includeBaseDirectory);
            using(var zipFileStream = new FileStream(destinationArchiveFileName, FileMode.Create)) {
                using (var archive = new ZipArchive(zipFileStream, ZipArchiveMode.Create)) {
                    for (int i = 0; i < filesToAdd.Length; i++) {
                        // Add the following condition to do filtering:
                        if (!filter(filesToAdd[i])) {
                            continue;
                        }
                        archive.CreateEntryFromFile(filesToAdd[i], entryNames[i], compressionLevel);
                    }
                }
            }
        }
    }
