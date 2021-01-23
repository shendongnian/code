    public static async Task<StorageFile> DecryptFile(IStorageFile file, string key, string destFilename)
    {
        var destFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync(destFilename, CreationCollisionOption.ReplaceExisting);
        var pwBuffer = CryptographicBuffer.ConvertStringToBinary(key, BinaryStringEncoding.Utf8);            
        using (var inputStream = await file.OpenStreamForReadAsync())
        {
            using (var outputStream = await destFile.OpenStreamForWriteAsync())
            {
                var engine = CipherUtilities.GetCipher("AES/ECB/PKCS7Padding");
                engine.Init(false, new KeyParameter(pwBuffer.ToArray().Take(16).ToArray()));
                var size = inputStream.Length;
                var current = inputStream.Position;
                var chunkSize = 1024 * 1024L;
                var lastChunk = false;
                await Task.Yield();
                // Initialize DataReader and DataWriter for reliable reading and writing
                // to a stream. Writing directly to a stream is unreliable.
                using (var reader = new BinaryReader(inputStream))
                using (var writer = new BinaryWriter(outputStream))
                {
                    while (current < size)
                    {
                        if (size - current < chunkSize)
                        {
                            chunkSize = (uint)(size - current);
                            lastChunk = true;
                        }
                        var chunk = new byte[chunkSize];
                        reader.Read(chunk, 0, (int)chunkSize);
                        // The last chunk must call DoFinal() as it appends additional bytes
                        var processedBytes = lastChunk ? engine.DoFinal(chunk) : engine.ProcessBytes(chunk);
                        writer.Write(processedBytes);
                        current = inputStream.Position;
                        await Task.Yield();
                    }
                    await outputStream.FlushAsync();
                }
            }
        }
        return destFile;
    }
