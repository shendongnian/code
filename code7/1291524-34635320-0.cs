    public event EventHandler<PacketEventArgs> PacketReceived;
    protected virtual void OnPacketReceived(byte[] packet)
    {
        var handler = PacketReceived;
        if (handler != null)
        {
            handler.Invoke(this, new PacketEventArgs(packet));
        }
    }
