    public async Task<string> ReadData()
    {
        StreamReader reader = new StreamReader(socket.InputStream.AsStreamForRead());
        char[] ch = new char[65536];
        int i = 0;
        while (true)
        {
            await reader.ReadAsync(ch, i++, 1);
            // break when the connection is closed or data ends with '\n\n'
            if (ch[i - 1] == '\0' || (i > 1 && ch[i - 1] == '\n' && ch[i - 2] == '\n')) break;
        }
        if (ch[i - 1] == '\0')
        {
            // do something here when the connection is closed
        }
        else
        {
            return new StringBuilder().Append(ch, 0, i - 2).ToString();
        }
    }
