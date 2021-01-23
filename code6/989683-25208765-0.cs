        private Task TransformStream_DesCbcPkcs7_WithProgress(bool forEncryption, Stream inputStream, Stream outputStream, byte[] key, byte[] iv, IProgress<int> progress)
        {
            return Task.Run(async () =>
            {
                // Initialize symmetric crypto engine
                // Algorithm:           DES
                // Mode of operation:   CBC
                // Byte padding:        PKCS#7
                var engine = new PaddedBufferedBlockCipher(new CbcBlockCipher(new DesEngine()), new Pkcs7Padding());
                engine.Init(forEncryption, new ParametersWithIV(new DesParameters(key), iv));
                // Report progress if available
                Action<int> report = x =>
                {
                    if (progress != null)
                        progress.Report(x);
                };
                var size = inputStream.Length;
                var current = inputStream.Position;
                var chunkSize = 1024 * 1024L;
                var lastChunk = false;
                report(0);
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
                        report((int)(current * 100F / size));
                        await Task.Yield();
                    }
                    await outputStream.FlushAsync();
                }
            });
        }
