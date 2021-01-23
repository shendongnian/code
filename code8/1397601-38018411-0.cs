    class Program
    {
        static void Main(string[] args)
        {
            var factoryType = typeof(MyChannelFactory).GetMethod("CreateProxyChannel", BindingFlags.Static | BindingFlags.Public);
            var generic = factoryType.MakeGenericMethod(myInterfaceType);
            var result = generic.Invoke(null, new[] { value});
            var channel = (myInterfaceType) result;
            var check = channel.Ping();
        }
        
    }
    class MyChannelFactory
    {
        public static T CreateProxyChannel<T>(string endpointName)
        {
            ChannelFactory<T> factory = new ChannelFactory<T>(endpointName);
            return factory.CreateChannel();
        }
    }
