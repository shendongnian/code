    static TcpListener StartServer()
    {
        Console.WriteLine("[*] Opening server...");
        TcpListener listener = new TcpListener(IPAddress.Any, 45784);
        listener.Start();
        Console.WriteLine("[*] Server waiting on port " + 45784);
        return listener;
    }
    static void Listen(CancellationToken cancellationToken)
    {
        string ip = GetIpAddress();
        Console.WriteLine("server on: ");
        var listener = StartServer();
        var client = listener.AcceptTcpClient();
        Console.WriteLine("Client connected!");
        var reader = new StreamReader(client.GetStream());
        while (!cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine(reader.ReadLine());
        }
    }
    static void Main(string[] args)
    {
        var cancellationSource = new CancellationTokenSource();
        Console.CancelKeyPress += (s, e) =>
        {
            e.Cancel = true;
            cancellationSource.Cancel();
        };
        Listen(cancellationSource.Token);
    }
