    static class FileModelCompression {
        public static Stream Compress(this IEnumerable<FileModel> files) {
            if (files.Any()) {
                var ms = new MemoryStream();
                using(var archive = new ZipArchive(ms, ZipArchiveMode.Create, leaveOpen: true)) {
                    foreach (var file in files) {
                        var entry = archive.add(file);
                    }
                }// disposal of archive will force data to be written to memory stream.
                ms.Position = 0; //reset memory stream position.
                return ms;
            }
            return null;
        }
        private static ZipArchiveEntry add(this ZipArchive archive, FileModel file) {
            var entry = archive.CreateEntry(file.FileName, CompressionLevel.Fastest);
            using (var stream = entry.Open()) {
                file.FileStream.CopyTo(stream);
            }
            return entry;
        }
    }
