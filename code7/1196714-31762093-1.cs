    interface ISocket : IDisposable
    {
        void Init();
        void Send();
        void Dispose();
    }
    public class Mycontroller
    {
        private readonly ISocket _singletonSocket;
        public Mycontroller(ISocket singletonSocket)
        {
            _singletonSocket = singletonSocket;
        }
        public void Init(){
            this._singletonSocket.Init();
        }
        public void Send()
        {
            this._singletonSocket.Send(); // handles the whole send/recieve logic
        }
        public void Dispose()
        {
            this._singletonSocket.Dispose();
        }
    }
