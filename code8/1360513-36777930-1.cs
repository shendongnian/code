    public static class FileModelCompression {
        public static Stream Compress(this IEnumerable<FileModel> files) {
            if (files.Any()) {
                var ms = new MemoryStream();
                var archive = new ZipArchive(ms, ZipArchiveMode.Create, false);
                foreach (var file in files) {
                    var entry = archive.add(file);
                }
                ms.Position = 0;
                return ms;
            }
            return null;
        }
        private static ZipArchiveEntry add(this ZipArchive archive, FileModel file) {
            var entry = archive.CreateEntry(file.UploadFileName, CompressionLevel.Fastest);
            using (var stream = entry.Open()) {
                stream.Write(file.UploadFileBytesStream, 0, file.UploadFileBytesStream.Length);
                stream.Position = 0;
                stream.Close();
            }
            return entry;
        }
    }
