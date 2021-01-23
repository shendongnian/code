    public static IEnumerable<byte[]> ReadChunks(string path)
    {
        var lengthBytes = new byte[sizeof(int)];
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            int n = fs.Read(lengthBytes, 0, sizeof (int));  // Read block size.
            if (n == 0)      // End of file.
                yield break;
            if (n != sizeof(int))
                throw new InvalidOperationException("Invalid header");
            int blockLength = BitConverter.ToInt32(lengthBytes, 0);
            var buffer = new byte[blockLength];
            n = fs.Read(buffer, 0, blockLength);
            if (n != blockLength)
                throw new InvalidOperationException("Missing data");
            yield return buffer;
        }
    }
