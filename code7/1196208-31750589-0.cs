    const string fileName = "Test.bin";
    const long fileSize = 1024L * 1024 * 16;
    const long windowSize = 1024 * 1024;
    if (!File.Exists(fileName)) {
        using (var file = File.Create(fileName)) {
            file.SetLength(fileSize);
        }
    }
    long realFileSize = new FileInfo(fileName).Length;
    if (realFileSize < fileSize) {
        using (var file = File.Create(fileName)) {
            file.SetLength(fileSize);
        }
    }
    using (var mm = MemoryMappedFile.CreateFromFile(fileName, FileMode.Open)) {
        long start = 0;
        while (true) {
            long size = Math.Min(fileSize - start, windowSize);
            if (size <= 0) {
                break;
            }
            using (var acc = mm.CreateViewAccessor(start, size)) {
                for (int i = 0; i < size; i++) {
                    // It is probably faster if you write the file with
                    // acc.WriteArray()
                    acc.Write(i, (byte)i);
                }
            }
            start += windowSize;
        }
    }
