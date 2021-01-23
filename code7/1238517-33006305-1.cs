    StreamReader reader = new StreamReader(tcpClient.GetStream());
    // first message is file size
    string cmdFileSize = reader.ReadLine();
    // first message is filename
    string cmdFileName = reader.ReadLine();
    int length = Convert.ToInt32(cmdFileSize);
    byte[] buffer = new byte[length];
    int received = 0;
    int read = 0;
    int size = 1024;
    int remaining = 0;
    using (StreamWriter writer = File.CreateText("outfile.dat"))
    {
        while (received < length)
        {
            remaining = length - received;
            if (remaining < size)
            {
                size = remaining;
            }
            read = tcpClient.GetStream().Read(buffer, received, size);
            received += read;
            writer.Writer(buffer);
            if (read < size)
            {
                break;
            }
        }
    }
