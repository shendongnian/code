    public byte[] GetChannelInfo(int deviceId, int channelId)
    {
        Device device;
        if (!Devices.TryGetValue(deviceId, out device))
        {
            // error, device doesn't exist.
        }
        Channel channel;
        if (!device.Channels.TryGetValue(channelId, out channel))
        {
            // error, channel does not exist on that device
        }
        return channel.ChannelData;
    }
