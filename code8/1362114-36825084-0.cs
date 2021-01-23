    public class AlarmPanel
    {
        public AlarmPanel(IConnection connection, int Password)
        {
            _connection = connection;
            _Password = Password;
            // Bind event.
            _connection.MessageReceived += ProcessMessage;
        }
    
        private void ProcessMessage(object sender, MessageEventArgs e)
        {
            // Do your central processing here with e.Message.
        }
    }
    public interface IConnection
    {
        event Action<object, MessageEventArgs> MessageRecieved;
    }
    public class TcpConnection : IConnection
    {
        // Other code.
        private static void processMessage(Response resp)
        {
           // Do something with the message here..
           var eventArgs = new MessageEventArgs
           {
               Message = response
           };
           OnMessageReceived(eventArgs);
        }
        protected virtual void OnMessageReceived(MessageEventArgs e)
        {
            // Call subscribers.
            var handler = MessageRecieved;
            if (handler != null) handler(this, e);
        }
        public event Action<object, MessageEventArgs> MessageRecieved;
    }
    // Class for passing Response back to AlarmPanel.
    public class MessageEventArgs : System.EventArgs
    {
        Response Message { get; set; } // Consider using an interface for Response.
    }
