    class Program
    {
        static void Main(string[] args)
        {
            var m = Global.Messages;
        }
    }
    [Serializable]
    public class Blah
    {
        [OnDeserialized]
        public void DoSomething(StreamingContext context)
        {
            Global.Channels.DoIt(this);
        }
    }
    static class Global
    {
        private static Blah _b = Deserialize();
        public static readonly IChannelsData Channels = new ChannelsData();
        public static readonly IMessagesData Messages = new MessagesData();
        public static Blah Deserialize()
        {
            var b = new Blah();
            b.DoSomething(default(StreamingContext));
            return b;
        }
    }
