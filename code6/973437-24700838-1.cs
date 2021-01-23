    public class MyServiceServer : IDisposable
    {
        public Boolean IsDisposed { get; private set; }
        ServiceHost host { get; set; }
        MyService service;
        public void Open()
        {
            if (host != null)
                Dispose();
            IsDisposed = false;
            service = new MyService();
            host = new ServiceHost(service, new Uri(Constants.myPipeService));
            host.AddServiceEndpoint(typeof(IMyService), new NetNamedPipeBinding(), Constants.myPipeServiceName);
            host.BeginOpen(OnOpen, host);
        }
        public void Msg(int ClientId)
        {
            foreach (var cb in service.Callbacks)
                if (cb.GetClientId() == ClientId) // CommunicationObjectAbortedException here
                    cb.RecieveMessage("We have called you choosen one");
        }
        public void Close()
        {
            host.BeginClose(OnClose, host);
        }
        public void Dispose()
        {
            ((IDisposable)host).Dispose();
            IsDisposed = true;
            host = null;
        }
        void OnOpen(IAsyncResult ar)
        {
            ServiceHost service = (ServiceHost)ar.AsyncState;
            service.EndOpen(ar);
        }
        void OnClose(IAsyncResult ar)
        {
            ServiceHost service = (ServiceHost)ar.AsyncState;
            service.EndClose(ar);
            Dispose();
        }
    }
