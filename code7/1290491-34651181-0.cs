     try
                {
                    HttpClient client = new HttpClient(); // Create HttpClient
                    byte[] buffer = await client.GetByteArrayAsync(coverUrl); // Download file
                    using (Stream stream = await coverpic_file.OpenStreamForWriteAsync())
                        stream.Write(buffer, 0, buffer.Length); // Save
                }
                catch
                {
                    saved = false;
                }
