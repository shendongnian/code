    internal class Program
    {
        public static void Main(string[] args1)
        {
            var config = new RpcServerConfiguration();
            config.BindingEndPoint = new IPEndPoint(IPAddress.Loopback, 8089);
            config.PreferIPv4 = true;
            config.IsDebugMode = true;
     //UseFullMethodName is a property that if it is false allows you in the CLIENT to call the         methods only by it's name, check example further.
            config.UseFullMethodName = false;
            var defaultServiceTypeLocator = new DefaultServiceTypeLocator();
            //Methods is the class I created with all the methods to be called.
            defaultServiceTypeLocator.AddService(typeof(Methods));
            config.ServiceTypeLocatorProvider = conf => defaultServiceTypeLocator;
            using (var server = new RpcServer(config))
            {
                server.Start();
                Console.ReadKey();
            }
        }
    [MessagePackRpcServiceContract] //Define the contract to be used   
    public class Methods 
    {
        [MessagePackRpcMethod] //Define the methods that are going to be exposed
        public string Hello()
        {
            return "Hello";
        }
        [MessagePackRpcMethod]
        public string HelloParam(string i)
        {
            return "Hello " + i;
        }
