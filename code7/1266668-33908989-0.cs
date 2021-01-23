    public sealed partial class MainPage : Page
    {
        DatagramSocket listenerSocket = null;
        const string port = "8080";
        public MainPage()
        {
            this.InitializeComponent();
            Listen();
            Send();
        }
    private async void Listen()
    {
        listenerSocket = new DatagramSocket();
        //listenerSocket.MessageReceived += (x, y) =>
        //{
        //    var a = "2";
        //};
        listenerSocket.MessageReceived += MessageReceived;
        await listenerSocket.BindServiceNameAsync(port);
    }
    private async void Send()
    {
        IOutputStream outputStream;
        string localIPString = GetLocalIp();
        IPAddress localIP = IPAddress.Parse(localIPString);
        string subnetMaskString = "255.0.0.0";
        IPAddress subnetIP = IPAddress.Parse(subnetMaskString);
        HostName remoteHostname = new HostName(localIP.ToString());
        outputStream = await listenerSocket.GetOutputStreamAsync(remoteHostname, port);
        
        using (DataWriter writer = new DataWriter(outputStream))
        {
            writer.WriteString("aaaa");
            await writer.StoreAsync();
        }
    }
    //private object GetBroadcastAddress(IPAddress localIP, IPAddress subnetIP)
    //{
    //    throw new NotImplementedException();
    //}
    async void MessageReceived (DatagramSocket socket, DatagramSocketMessageReceivedEventArgs args)
    {
        DataReader reader = args.GetDataReader();
        uint len = reader.UnconsumedBufferLength;
        string msg = reader.ReadString(len);
        string remoteHost = args.RemoteAddress.DisplayName;
        reader.Dispose();
        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
            text.Text = msg;
        });
    }
    private string GetLocalIp()
    {
        string str = null;
        
        foreach (HostName localHostName in NetworkInformation.GetHostNames())
        {
            if (localHostName.IPInformation != null)
            {
                if (localHostName.Type == HostNameType.Ipv4)
                {
                    str = localHostName.ToString();
                }
            }
        }
        return str;
    }
}
