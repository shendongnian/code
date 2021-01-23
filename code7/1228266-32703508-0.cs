    public void ConvertLargeFile(string source , string destination)
    {
        using (FileStream inputStream = new FileStream(source, FileMode.Open, FileAccess.Read))
        { 
            int buffer_size = 30000; //or any multiple of 3
            byte[] buffer = new byte[buffer_size];
            int bytesRead = inputStream.Read(buffer, 0, buffer.Length);
            while (bytesRead > 0)
            {
                byte[] buffer2 = buffer;
                if(bytesRead < buffer_size)
                {
                    buffer2 = new byte[bytesRead];
                    Buffer.BlockCopy(buffer, 0, buffer2, 0, bytesRead);
                }
                string base64String = System.Convert.ToBase64String(buffer2);
                File.AppendAllText(destination, base64String);
                bytesRead = inputStream.Read(buffer, 0, buffer.Length);
            }
        }
    }
