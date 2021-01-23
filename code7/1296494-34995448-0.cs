    public abstract class NetWebSocket
    {
        private Func<object, Task<object>>  SendImpl { get; set; }
        protected NetWebSocket(Func<object, Task<object>> sendImpl)
        {
            this.SendImpl = sendImpl;
        }
        protected abstract Task ReceiveAsync(string message);
        public Func<object, Task<object>> ReceiveImpl
        {
            get
            {
                return async (input) =>
                {
                    Console.Out.WriteLine(input);
                    await this.ReceiveAsync((string) input);
                    return Task.FromResult<object>(null);
                };
            }
        }
        protected async Task SendAsync(string message)
        {
            await this.SendImpl(message);
            return;
        }
    }
    public class MyNetWebSocketImpl : NetWebSocket
    {
        public CHello module;
        private string JSONCodelineDataRepr = "not set";
        public MyNetWebSocketImpl(Func<object, Task<object>> sendImpl) : base(sendImpl)
        {
            // do other stuff after calling the super class constructor  
            module = new CHello();
            module.DocumentReadEvent += this.DocumentReadEventHandler;
            module.DocumentReadErrorEvent += this.DocumentReadErrorEventHandler;
            // uncomment after the websocket communication works
            module.Start();
        }
        protected override async Task ReceiveAsync(string message)
        {
            // not really needed because only the NodeJS Server listens to C# .NET Server messages
            Console.WriteLine(message);
            if (message.Equals("shutdown"))
            {
                module.Close();
            }
            // not necessary (can comment the send function call)
            // if I eventually receive a message, respond with the JSON representation of the Patient ID Card
            await this.SendAsync("I received a message from you, but I'll ignore it and send you the Patient" +
                                 " ID Card Data instead.. I'm a fish, so start phishing! PersonData = " +
                                 JSONCodelineDataRepr);
            return;
        }
        private async void DocumentReadEventHandler(string args)
        {
            this.JSONCodelineDataRepr = args;
            await this.SendAsync(args);
        }
        private async void DocumentReadErrorEventHandler(string args)
        {
            await this.SendAsync(args);
        }
    }
    public class Startup
    {
        
        public static MyNetWebSocketImpl ws;
        public async Task<object> Invoke(Func<object, Task<object>> sendImpl)
        {
            ws = new MyNetWebSocketImpl(sendImpl);
           
            return ws.ReceiveImpl;
        }
    }
