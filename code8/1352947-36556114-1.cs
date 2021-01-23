    <pre><code>
        public class ConnectionMapping
        {
            private readonly List<SingleConnection> _connections = new List<SingleConnection>();
            public int Count
            {
                get
                {
                    return _connections.Count;
                }
            }
            public void Add(string key, string connectionId)
            {
                lock (_connections)
                {
                    var sn = _connections.Where(x => x.Id == key).FirstOrDefault();
                    if (sn != null) // there is a connection with this key
                    {
                        _connections.Find(x => x.Id == key).ConnectionId.Add(connectionId);
                    }
                    else
                    {
                        _connections.Add(new SingleConnection { Id = key, ConnectionId = new List<string> { connectionId } });
                    }
                }
            }
            public List<string> GetConnections(string id)
            {
                var con = _connections.Find(x => x.Id == id);
                return con != null ?  con.ConnectionId : new List<string>();
            }
            public List<string> AllConnectionIds() 
            {
                List<string> results = new List<string>();
                 var allItems = _connections.Where(x => x.ConnectionId.Count > 0).ToList();
                 foreach (var item in allItems)
                 {
                     results.AddRange(item.ConnectionId);
                 }
                 return results;
            }
            public List<string> AllKeys() 
            {
                return _connections.Select(x => x.Id).ToList();
            }
            public void Remove(string key, string connectionId)
            {
                lock (_connections)
                {
                    var item = _connections.Find(x => x.Id == key);
                    if (_connections.Find(x => x.Id == key) != null)
                    {
                        _connections.Find(x => x.Id == key).ConnectionId.Remove(connectionId);
                        if (_connections.Find(x => x.Id == key).ConnectionId.Count == 0)
                        {
                            _connections.Remove(item);
                        }
                    }
                }
            }
        }
    </code></pre>
	
	
    
    
    - In my Hub Class
	
	
	
	
    <pre><code>
    private void IsActive(string connection, bool connected) 
    {
        Clients.All.clientconnected(connection, connected);
    }
    public override Task OnConnected()
    {
        string name = Context.User.Identity.Name;
        _connections.Add(name, Context.ConnectionId);
        IsActive(name, true);
        return base.OnConnected();
    }
    public override Task OnDisconnected(bool stopCalled)
    {
        string name = Context.User.Identity.Name;
        _connections.Remove(name, Context.ConnectionId);
        IsActive(name, false);
        return base.OnDisconnected(stopCalled);
    }
    public override Task OnReconnected()
    {
        string name = Context.User.Identity.Name;
        if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
        {
            _connections.Add(name, Context.ConnectionId);
        }
        IsActive(name, false);
        return base.OnReconnected();
    }
