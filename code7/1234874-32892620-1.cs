    using (var tcpClient = new TcpClient("127.0.0.1", 1234))
    {
        using(var ns = tcpClient.GetStream())
        {
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            string data;
            //receiving message
            data = sr.ReadLine();
            if(data == somePreDeterminedValue)
            {
                Console.WriteLine(data);
            }
        }
    }
