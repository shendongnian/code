    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Web;
    using System.Threading.Tasks;
    
    namespace TestApp
    {
        class Program
        {
    
            private static NetConnection fakeServerConnector { get; set; }
    
            static void Main(string[] args)
            {
                var pageHandler = new MyHandler();
                var tw = Console.Out;
                var builder = new UriBuilder();
                builder.Host = "localhost";
                builder.Port = 80;
                builder.Query = "";
    
                initFakeServer(8080);
    
                pageHandler.ProcessRequest(
                    new HttpContext(
                        new HttpRequest("index.html", builder.ToString(), ""),
                        new HttpResponse(tw))
                        );
                ConsoleKey key;
                do
                {
                    key = Console.ReadKey().Key;
                } while (!(key == ConsoleKey.Enter || key == ConsoleKey.Escape));
            }
    
            private static void initFakeServer(int Port)
            {
                fakeServerConnector = new NetConnection();
                fakeServerConnector.OnDataReceived += fakeServerConnector_OnDataReceived;
                fakeServerConnector.Start(Port);
    
            }
    
            static void fakeServerConnector_OnDataReceived(object sender, NetConnection connection, byte[] e)
            {
                var msg = System.Text.UTF8Encoding.UTF8.GetBytes("Fake Server says: \"Hi\"");
                connection.Send(msg);
            }
        }
    
        public class MyHandler : IHttpHandler
        {
    
            public string HostName { get; set; }
            public int Port { get; set; }
            private NetConnection clientConnector { get; set; }
            private bool isReceived;
            private byte[] responsePayload;
    
            public bool IsReusable
            {
                get { return false; }
            }
    
           
    
            public void ProcessRequest(HttpContext context)
            {            
                HostName = "localhost";
                Port = 8080;
    
                clientConnector = new NetConnection();
                clientConnector.OnDataReceived += OnDataReceivedHandler;
                clientConnector.Connect(HostName, Port);
                clientConnector.Send(System.Text.UTF8Encoding.UTF8.GetBytes("Client Connector says: \"Hello World\""));
                while (!isReceived)
                {
                    // do nothing; wait for isReceived to become true;
                }
                var responsePayloadText = System.Text.ASCIIEncoding.UTF8.GetString(responsePayload, 0, responsePayload.Length);
                context.Response.Write(responsePayloadText);
            }
    
    
            public void OnDataReceivedHandler(object sender, NetConnection connection, byte[] data)
            {
                isReceived = true;
                responsePayload = data;
            }
        }    
    }
