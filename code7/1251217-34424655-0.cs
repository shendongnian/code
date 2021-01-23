    // Define static class here.
    
    public static StreamSocketListener Listener { get; set; }
    
    // This is the static method used to start listening for connections.
    
     public static async Task<bool> StartServer()
     {
          Listener = new StreamSocketListener();
          // Removes binding first in case it was already bound previously.
          Listener.ConnectionReceived -= Listener_ConnectionReceived;
          Listener.ConnectionReceived += Listener_ConnectionReceived;
          try
          {
               await Listener.BindServiceNameAsync(ViewModel.Current.Port); // Your port goes here.
               return true;
           }
           catch (Exception ex)
           {
              Listener.ConnectionReceived -= Listener_ConnectionReceived;
              Listener.Dispose();
              return false;
            }
     }
    
     private static async void Listener_ConnectionReceived(StreamSocketListener sender, StreamSocketListenerConnectionReceivedEventArgs args)
     {
          var remoteAddress = args.Socket.Information.RemoteAddress.ToString();
          var reader = new DataReader(args.Socket.InputStream);
          var writer = new DataWriter(args.Socket.OutputStream);
          try
          {
              // Authenticate client here, then handle communication if successful.  You'll likely use an infinite loop of reading from the input stream until the socket is disconnected.
          }
          catch (Exception ex)
          {
               writer.DetachStream();
               reader.DetachStream();
               return;
          }
     }
