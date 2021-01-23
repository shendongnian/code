    private static string LastLine1(NetworkStream networkStream)
    {
        string result = null;
        while (!Program.ShouldStop)
        {
            StreamReader streamReader2;
            StreamReader streamReader = streamReader2 = new StreamReader(networkStream);
            try
            {
                string text = streamReader.ReadLine();
                if (text != null)
                {
                    result = text;
                }
            }
            finally
            {
                if (streamReader2 != null)
                {
                    ((IDisposable)streamReader2).Dispose();
                }
            }
        }
        return result;
    }
    private static string LastLine2(NetworkStream networkStream)
    {
        string result = null;
        while (!Program.ShouldStop)
        {
            using (StreamReader streamReader = new StreamReader(networkStream))
            {
                string text = streamReader.ReadLine();
                if (text != null)
                {
                    result = text;
                }
            }
        }
        return result;
    }
