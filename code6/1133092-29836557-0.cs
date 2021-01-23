        public class WebSocketHelper : IDisposable
        {
           private string _incomingMessage;
           private AutoResetEvent _messageReceivedEvent = new AutoResetEvent(false);
           ...
    
           public string Send(string message)
           {
              this.outgoingMessage = message;
              webSocket.Open();
              this._messageReceivedEvent.WaitOne(); 
              return this._incomingMessage; 
           }
        
           private void webSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
           {
              this._incomingMessage = e.Message;
              this._messageReceivedEvent.Set();
           }
           ...
        }
