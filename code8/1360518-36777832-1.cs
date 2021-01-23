    Dictionary<Type, Action<NetMessage>> messageHandlers = new Dictionary<Type, Action<NetMessage>>();
    void RegisterHandler(Type type, Action<NetMessage> handler)
    {
        messageHandlers.Add(type, handler);
    }
    void MessageReceived(NetMessage message)
    {
        messageHandlers[message.GetType()].Invoke(message);
    }
