    public void Disconnect()
    {
        bool doEvent;
        lock(commander) {
            var tmp = commander.IsConnected;
            commander.Disconnect();
            doEvent = (commander.IsConnected != tmp && !commander.IsConnected)
        }
        // Run OnPropertyChanged outside the locked context 
        if (doEvent)
        {
            OnPropertyChanged("IsConnected");
        }
    }
