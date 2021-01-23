    public class Server
    {
        ManualResetEvent allDone = new ManualResetEvent(false);
        Thread _socketThread;
        ListBox logs;
        public Server(ListBox lb)
        {
            logs = lb;
        }
        public void Start()
        {
            _socketThread = new Thread(SocketThreadFunc);
            _socketThread.Start();
        }
        public void SocketThreadFunc(object state)
        {
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Loopback, 1440));
            while (true)
            {
                Console.Out.WriteLine("Waiting for connection...");
                allDone.Reset();
                listener.Listen(100);
                listener.BeginAccept(Accept, listener);
                allDone.WaitOne(); //halts this thread
            }
        }
        //other methods like Send, Receive etc.
    }
