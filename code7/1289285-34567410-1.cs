    public void TimeUp(object source, ElapsedEventArgs e)
    {
        IPv4InterfaceStatistics statistics = adapters[0].GetIPv4Statistics();
        var sent = statistics.BytesSent - bytes;
        Dispatcher.Invoke(DispatcherPriority.Normal, new Action<Label>(SetValue), uploadLabel, sent);
        bytes = statistics.BytesSent;
    }
