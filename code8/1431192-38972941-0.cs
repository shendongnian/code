    class MainClass
    {
        static void Main(string[] args)
        {
            // Test if input arguments were supplied:
            var switchvalue = int.Parse(args[1]);
            if (switchvalue == 1)
                    {
                int port = int.Parse(args[2]);
                server = new TcpListener(IPAddress.Any, port);
                //Rest of the program
            }
            if (switchvalue == 2)
            {
                int port = int.Parse(args[2]);
                server = new TcpListener(IPAddress.Any, port);
                //Rest of the program
            }
            if (switchvalue == 3)
            {
                int port = int.Parse(args[2]);
                server = new TcpListener(IPAddress.Any, port);
                //Rest of the program
            }
        }
    }
