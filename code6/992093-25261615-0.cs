    public void Disconnect()
    {
        lock (commander)
        {
            var tmp = commander.IsConnected;
            commander.Disconnect();
            if (commander.IsConnected != tmp && !commander.IsConnected)
                OnPropertyChanged("IsConnected");
        }
    }
