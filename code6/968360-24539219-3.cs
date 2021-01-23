    // 'Connected' property is unreliable
    if (client.Connected)
    {
        var buf = new byte[0];
        // this should send and empty TCP packet over the wire
        // and update socket state
        client.Client.Send(buf);
        return client.Connected;
    }
