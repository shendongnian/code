    public interface IWebSocketService
    {
       void onReceive(String msg);
    }
    public abstract class WebSocketBase : IWebSocketService
    {
    ...
    private void webSocketClient_MessageReceived(object sender, MessageEventArgs e)
    {
        webService.onReceive(e.Data);
    }
      public void sendData(string data)
      {
          send("data");
      }
    }
    public class Logic : WebSocketBase
    {
        public void onReceive(string msg)
        {
             Console.WriteLine("Received message")
        }
    }
