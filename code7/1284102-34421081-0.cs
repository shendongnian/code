    public class Proxy<T>
    {
        public ChannelFactory<T> Channel { get; set; }
    
        public Proxy()
        {
            Channel = new ChannelFactory<T>("endpoint");
        }
    
        public T CreateChannel()
        {
            return Channel.CreateChannel();
        }
    }
