            private static readonly ConcurrentDictionary<string, string> _connections = new ConcurrentDictionary<string, string>();
     
            public void SayHello(string message)
            {
                Clients.Others.hello(message);
            }
    
            public override System.Threading.Tasks.Task OnConnected()
            {
                _connections.TryAdd(Context.ConnectionId, string.Empty);
                return base.OnConnected();
            }
            public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
            {
                string value;
                _connections.TryRemove(Context.ConnectionId, out value);
                return base.OnDisconnected(stopCalled);
            }
