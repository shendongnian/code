    private static string LastLine1(NetworkStream networkStream)
    {
        string last = null;
        StreamReader reader;
        while(!ShouldStop)
        {
            using(reader = new StreamReader(networkStream))
            {
                string line = reader.ReadLine();
                if(line != null)
                    last = line;
            }
        }
        return last;
    }
    private static string LastLine2(NetworkStream networkStream)
    {
        string last = null;
        while(!ShouldStop)
        {
            using(StreamReader reader = new StreamReader(networkStream))
            {
                string line = reader.ReadLine();
                if(line != null)
                    last = line;
            }
        }
        return last;
    }
