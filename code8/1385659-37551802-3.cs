    Dictionary<Channel, YourEventHandler> _handlers = new Dictionary<Channel, YourEventHandler>();
    
    ...
    if (condition)
        foreach (var channel in dataSource.Channels)
        {
            if (!_handlers.ContainsKey(channel)) {
                YourEventHandler handler = (s, vals) => AddSamples(channel.Index, vals);
                channel.NewSamples += handler;
                _handlers[channel] = handler;
            }
        }
    }
    else
    {
        foreach (var channel in dataSource.Channels)
        {
            if (_handlers.ContainsKey(channel)) {
                 channel.NewSamples -= _handlers[channel];
                 _handlers.Remove(channel);
            }
        }
    }
    
