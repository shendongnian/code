          using (MemoryStream inputStream = new MemoryStream(fetchedimgbytes))
            {
                using (Stream file = File.Create(path))
                {
                    byte[] buffer = new byte[8 * 1024];
                    int len;
                    while ((len = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        file.Write(buffer, 0, len);
                    }
                }
            }
