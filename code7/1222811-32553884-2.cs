    // Create your own class to hold the data
    public class DataReceivedEventArgs : EventArgs
    {
      public uint DataCount { get; private set; }
      public DataReceivedEventArgs(uint dataCount)
      {
        DataCount = dataCount;
      }
    }
    // Now inside your MainPage...
    bool m_keepReading = false;
    bool m_eventHandled = false;
    public event TypedEventHandler<MainPage, DataReceivedEventArgs> DataReceived;
    // Hook this up to (eg) a Button
    private async void StartSockets(object sender, RoutedEventArgs e)
    {
      if (!m_eventHandled)
        DataReceived += (s, args) => Debug.WriteLine(args.DataCount);
      m_eventHandled = true;
      m_keepReading = true;
      DoSocketTestAsync();
    }
    // Hook this up to (eg) a Button
    private void StopSockets(object sender, RoutedEventArgs e)
    {
      m_keepReading = false;
    }
    private async Task DoSocketTestAsync()
    {
      var socket = new StreamSocket();
      await socket.ConnectAsync(new HostName("www.microsoft.com"), "http");
      var writer = new DataWriter(socket.OutputStream);
      writer.WriteString("GET /en-us HTTP/1.1\r\nHOST: www.microsoft.com\r\n\r\n");
      await writer.StoreAsync();
      ReadSocketAsync(socket);
    }
    private async void ReadSocketAsync(StreamSocket socket)
    {
      while (m_keepReading)
      {
        const uint size = 2048;
        IBuffer buffer = new Windows.Storage.Streams.Buffer(size);
        buffer = await socket.InputStream.ReadAsync(buffer, size,
         InputStreamOptions.Partial);
        var handler = DataReceived; 
        if (handler != null && buffer.Length > 0)
          handler(this, new DataReceivedEventArgs(buffer.Length));
      }
    }
