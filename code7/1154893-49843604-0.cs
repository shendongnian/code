    using System;
    using System.Net;
    using System.Net.WebSockets;
    using System.Text;
    using System.Threading;
    
    
    namespace WebSocketServerConsole
    {
        public class Program
        {
            static HttpListener httpListener = new HttpListener();
            private static Mutex signal = new Mutex();
            public static void Main(string[] args)
            {
                httpListener.Prefixes.Add("http://localhost:8080/");
                httpListener.Start();
                while (signal.WaitOne())
                {
                    ReceiveConnection();
                }
            }
    
            public static async System.Threading.Tasks.Task ReceiveConnection()
            {
                HttpListenerContext context = await 
                httpListener.GetContextAsync();
                if (context.Request.IsWebSocketRequest)
                {
                    HttpListenerWebSocketContext webSocketContext = await context.AcceptWebSocketAsync(null);
                    WebSocket webSocket = webSocketContext.WebSocket;
                    while (webSocket.State == WebSocketState.Open)
                    {
                        await webSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes("Hello world")),
                            WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                }
                signal.ReleaseMutex();
            }
        }
    }
