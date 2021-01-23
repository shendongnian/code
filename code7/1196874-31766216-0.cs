    // You encryption/decryption key as a bytes array
    var key = Encoding.UTF8.GetBytes("secretpassword");
    var cipher = new RC4Engine();
    var keyParam = new KeyParameter(key);
    // for decrypting the file just switch the first param here to false
    cipher.Init(true, keyParam);
    using (var inputFile = new FileStream(@"C:\path\to\your\input.file", FileMode.Open, FileAccess.Read))
    using (var outputFile = new FileStream(@"C:\path\to\your\output.file", FileMode.OpenOrCreate, FileAccess.Write))
    {
        // processing the file 4KB at a time.
        byte[] buffer = new byte[1024 * 4];
        long totalBytesRead = 0;
        long totalBytesToRead = inputFile.Length;
        while (totalBytesToRead > 0)
        {
            int read = inputFile.Read(buffer, 0, buffer.Length);
            // break the loop if we didn't read anything (EOF)
            if (read == 0)
            {
                break;
            }
            totalBytesRead += read;
            totalBytesToRead -= read;
            byte[] outBuffer = new byte[1024 * 4];
            cipher.ProcessBytes(buffer, 0, read, outBuffer,0);
            outputFile.Write(outBuffer,0,read);
        }
    }
