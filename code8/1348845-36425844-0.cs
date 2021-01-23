    int desiredChunkNumber = 3;
    using (Stream input = File.OpenRead(inputFile)) {
        input.Position = (desiredChunkNumber - 1) * chunkSize;
        using (Stream output = File.Create(path)) {
            int remaining = chunkSize, bytesRead;
            while (remaining > 0 && (bytesRead = input.Read(buffer, 0,
                        Math.Min(remaining, BUFFER_SIZE))) > 0) {
                output.Write(buffer, 0, bytesRead);
                remaining -= bytesRead;
            }
        }
    }
