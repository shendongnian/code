    public sealed class ServiceClient
    {
        private readonly ChannelFactory<IMyService> _channelFactory;
        public ServiceClient( Binding binding, EndpointAddress endpointAddress )
        {
            _channelFactory = new ChannelFactory<IMyService>( binding, endpointAddress );
            Channel = _channelFactory.CreateChannel();
        }
        public IMyService Channel { get; private set; }
        public void Dispose()
        {
            if( Channel != null )
            {
                // TODO: check the state of the channel and close/abort appropriately
            }
            if( _channelFactory != null )
            {
                _channelFactory.Close();
            }
        }
    }
    public sealed class MyWrapper
    {
        public ServiceClient GetClient()
        {
            // Similar setup to the previous example, except the service client wraps
            // the channel factory.
        }
    }
    var wrapper = new Wrapper();
    using( var client = wrapper.GetClient() )
    {
        client.Channel.Foo( 123 );
    }
