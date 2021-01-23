        _proxy.InnerChannel.Opening += OnChannelOpening;
        _proxy.InnerChannel.Opened += OnChannelOpened;
        _proxy.InnerChannel.Faulted += OnChannelFaulted;
        _proxy.InnerChannel.UnknownMessageReceived += OnChannelUnknownMessageReceived;
        _proxy.InnerChannel.Closing += OnChannelClosing;
        _proxy.InnerChannel.Closed += OnChannelClosed;
