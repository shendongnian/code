            var src = await KnownFolders
                            .PicturesLibrary
                            .GetFileAsync("210644575939381015.jpg")
                            .AsTask();
            var target = await KnownFolders
                            .PicturesLibrary
                            .CreateFileAsync("new_file.jpg")
                            .AsTask();
            using (var srcStream = await src.OpenAsync(FileAccessMode.Read))
            using (var targetStream = await target.OpenAsync(FileAccessMode.ReadWrite))
            using (var reader = new DataReader(srcStream.GetInputStreamAt(0)))
            {
                var output = targetStream.GetOutputStreamAt(0);
                await reader.LoadAsync((uint)srcStream.Size);
                while (reader.UnconsumedBufferLength > 0)
                {
                    uint dataToRead = reader.UnconsumedBufferLength > 64
                                        ? 64
                                        : reader.UnconsumedBufferLength;
                    IBuffer buffer = reader.ReadBuffer(dataToRead);
                    await output.WriteAsync(buffer);
                }
                await output.FlushAsync();
            }
