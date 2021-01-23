    void MyMethod(Server server, Action<NetOutgoingMessage> action)
    {
        NetOutgoingMessage om = server.CreateMessage();
        action(om);
        server.SendMessage(om, server.Connections, NetDeliveryMethod.UnreliableSequenced, 0);     
    }
