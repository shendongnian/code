    // Exclude File.DeleteCode
    using (FileStream fs = File.Create(pathname))
    {
        Byte[] info = new UTF8Encoding(true).GetBytes(writeline);
        // Add some information to the file.
        fs.Write(info, 0, info.Length);
        fs.Close();  // Close the stream
    }
