    public sealed class MyWrapper
    {
        public IMyService GetService()
        {
            // TODO: perform appropriate OS-wide locking here
            
            // TODO: see if app is running
    
            // TODO: if not, launch it in a new process
    
            // create a channel to connect the WCF endpoint we just defined
            var channel = GetChannel();
    
            // TODO: release lock
    
            // return the channel to the caller
            return channel;
        }
    
        public GetChannel( Binding binding, EndpointAddress endpointAddress )
        {
            var channelFactory = new ChannelFactory<IMyService>( binding, endpointAddress );
            return _channelFactory.CreateChannel();
        }
    }
