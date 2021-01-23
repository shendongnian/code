    using CookComputing.XmlRpc;
    
    namespace xmlrpc
    {
        [XmlRpcUrl("http://localhost:7362")]
        public interface FlRPC : IXmlRpcProxy
        {
            [XmlRpcMethod("main.tx")]
            String MainTx();
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                FlRPC proxy = XmlRpcProxyGen.Create<FlRPC>();
                Console.WriteLine(proxy.MainTx());
                Console.ReadLine();
            }
        }
    }
