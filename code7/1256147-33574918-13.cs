    namespace WCFClient
    {
        [ServiceContract]
        public interface IUtils
        {
            [OperationContract]
            void PostPID(int value);
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                ChannelFactory<IUtils> pipeFactory =
                  new ChannelFactory<IUtils>(
                    new NetNamedPipeBinding(),
                    new EndpointAddress(
                      "net.pipe://localhost/Pipepipe"));
    
                IUtils pipeProxy =
                  pipeFactory.CreateChannel();
    
                pipeProxy.PostPID(Process.GetCurrentProcess().Id);
            }
        }
    }
