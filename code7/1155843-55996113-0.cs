    using System;
    using System.Threading.Tasks;
    using WebSocketSharp;
    
    namespace Example
    {
        class Program
        {
            private static void Main(string[] args)
            {
                using (var ws = new WebSocket(url: "ws://localhost:1337", onMessage: OnMessage, onError: OnError))
                {
                    ws.Connect().Wait();
                    ws.Send("Hey, Server!").Wait();
                    Console.ReadKey(true);
                }
            }
    
            private static Task OnError(ErrorEventArgs errorEventArgs)
            {
                Console.Write("Error: {0}, Exception: {1}", errorEventArgs.Message, errorEventArgs.Exception);
                return Task.FromResult(0);
            }
    
            private static Task OnMessage(MessageEventArgs messageEventArgs)
            {
                Console.Write("Message received: {0}", messageEventArgs.Text.ReadToEnd());
                return Task.FromResult(0);
            }
        }
    }
