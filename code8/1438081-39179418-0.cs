    private Lazy<SerialConnection> _serialConnection =new Lazy<SerialConnection>(StaticClass.GetStaticSerialConnection);
    public SerialConnection MySerialConnection
    {
      get { return _serialConnection.Value; }
    }
