    public static void Main(String[] args)
    {
    iPhone my_device_instance = new iPhone();
    my_device_instance.Connect += new ConnectEventHandler(onConnect);
    my_device_instance.Disconnect += new ConnectEventHandler(onDisconnect);
    Console.WriteLine("Waiting for device...");
    System.Threading.Thread.Sleep(-1)
    }
    
    static void onConnect(object sender, ConnectEventArgs e)
    {
    // Do stuff...
    }
    
    static void onDisconnect(object sender, ConnectEventArgs e)
    {
    // Do stuff...
    }
