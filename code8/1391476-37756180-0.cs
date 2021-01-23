    public class Channel
    {
        public int ChannelNumber {get; private set;}
        public byte[] ChannelData {get; set; }
        // constructor, etc.
    }
    public class Device
    {
        public int DeviceNumber {get; private set; }
        public Dictionary<int, Channel> Channels {get; private set; }
        // constructor, etc.
    }
