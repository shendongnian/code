        public Task<string> ReadTextAsync(string filePath)
        {
            var task = new Task<string>(() =>
            {
                Thread.Sleep(5000);
                using (FileStream sourceStream = new FileStream(filePath,
    FileMode.Open, FileAccess.Read, FileShare.Read,
    bufferSize: 4096, useAsync: true))
                {
                    StringBuilder sb = new StringBuilder();
    
                    byte[] buffer = new byte[0x1000];
                    int numRead;
                    while ((numRead = sourceStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        string text = Encoding.ASCII.GetString(buffer, 0, numRead);
                        sb.Append(text);
                    }
    
                    return sb.ToString();
                }
            });
            task.Start();
            return task;
        }
