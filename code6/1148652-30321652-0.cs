    class Example
    {
        private Promise BeginSocketConnection()
        {
            Deferred retPromise = new Deferred();
    
            socket.On("connect", (fn) =>
            {
                // We're no longer on the main thread ):
                // But we can resolve our promise!
                retPromise.Resolve();
            });
    
            return retPromise;
        }
    
        private void SocketConnectedSuccessfully()
        {
           // Executing on main thread
        }
    
        private void Start()
        {
            // We start in the main thread
            BeginSocketConnection().Done(x =>
            {
                SocketConnectedSuccessfully();
            });
        }
    }
