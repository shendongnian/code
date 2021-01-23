    // Create your own class to hold the data
    public class DataReceivedEventArgs : EventArgs
    {
      public string Data { get; private set; }
      public DataReceivedEventArgs(string data)
      {
        Data = data;
      }
    }
    // ...
    // Declare the event inside your class
    public event TypedEventHandler<TCPTransport, DataReceivedEventArgs> DataReceived;
    // ...
    // When data is available, you want to raise the event if
    // there are any listeners.
    var handler = DataReceived;
    if (handler != null)
      handler(this, new DataReceivedEventArgs(data));
