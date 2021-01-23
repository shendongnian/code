    private static int GetResponce(string request)
    {
        TcpClient connectionSocket = new TcpClient("localhost", 5678);
        Stream ns = connectionSocket.GetStream();
        StreamReader sr = new StreamReader(ns);
        StreamWriter sw = new StreamWriter(ns);
        sw.AutoFlush = true;
        sw.WriteLine(request);
        string message = sr.ReadLine();
        return Convert.ToInt32(message);
    }
