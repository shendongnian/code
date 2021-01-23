        public async Task ChunkUpload(DropboxClient client, string folder, string localContentFullPath)
        {
            Console.WriteLine("Chunk upload file...");
            // Chunk size is 128KB.
            const int chunkSize = 128 * 1024;
            // Create a random file of 1MB in size.
            // var fileContent = new byte[1024 * 1024];
            // new Random().NextBytes(fileContent);
            //using (var stream = new MemoryStream(fileContent))
            var filename = System.IO.Path.GetFileName(localContentFullPath.ToString());
            using (var stream = new FileStream(localContentFullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    ...
