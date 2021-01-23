    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    
    namespace WCFTest
    {
        class Program
        {
            public interface ICallbackService
            {
                [OperationContract(IsOneWay = true)]
                void Authenticate(bool authenticated);
            }
            [ServiceContract(SessionMode = SessionMode.Allowed, CallbackContract = typeof(ICallbackService))]
            public interface IService
            {
                [OperationContract(IsOneWay = true)]
                void Login(string email, string password);
    
                [OperationContract(IsOneWay = true)]
                void Logout(string email);
            }
            [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
            public class Service : IService
            {
                private Dictionary<string, ICallbackService> _clientDict = new Dictionary<string, ICallbackService>();
    
                public void Login(string email, string password)
                {
                    WriteInfoAboutInvoker("Login");
    
                    // Get client callback
                    var callback = OperationContext.Current.GetCallbackChannel<ICallbackService>();
                    lock (_clientDict)
                    {
                        _clientDict.Add(email, callback);
                        Console.WriteLine("Added '{0}'", email);
                    }
                }
                public void Logout(string email)
                {
                    WriteInfoAboutInvoker("Logout");
                    lock (_clientDict)
                    {
                        if (_clientDict.ContainsKey(email))
                        {
                            _clientDict.Remove(email);
                            Console.WriteLine("Removed '{0}'", email);
                        }
                    }
                }
                private void WriteInfoAboutInvoker(string method)
                {
                    var ctx = OperationContext.Current;
                    var msgProp = ctx.IncomingMessageProperties;
                    var endpoint = msgProp[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
    
                    Console.WriteLine("Invoked {0} from {1}:{2}. SessionId: {3}", method, endpoint.Address, endpoint.Port, ctx.SessionId);
                }
            }
            public class ServiceClient : IDisposable, ICallbackService, IService
            {
                private readonly string _cs;
                private IService _service;
                private DuplexChannelFactory<IService> _channel;
                /// <summary>
                /// 
                /// </summary>
                /// <param name="cs">Format is 'hostname:port'</param>
                public ServiceClient(string cs)
                {
                    if (string.IsNullOrEmpty(cs))
                        throw new ArgumentException("cs");
                    _cs = cs;
                }
                public void Connect()
                {
                    try { InternalConnect(); }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("Can't connect to server '{0}'. Error: {1}", _cs, ex.Message));
                    }
                }
                public void Dispose()
                {
                    try
                    {
                        _channel.Closed -= Channel_Closed;
                        _channel.Faulted -= Channel_Faulted;
                        _channel.Close();
                    }
                    catch { }
                }
                private void InternalConnect()
                {
                    InstanceContext ctx = new InstanceContext(this);
                    NetTcpBinding tcpBinding = CreateBindings();
                    _channel = new DuplexChannelFactory<IService>(ctx, tcpBinding, new EndpointAddress("net.tcp://" + _cs));
                    _channel.Closed += Channel_Closed;
                    _channel.Faulted += Channel_Faulted;
                    _service = _channel.CreateChannel();
                }
                void Channel_Closed(object sender, EventArgs e)
                {
                    Console.WriteLine("Channel closed");
                }
                private NetTcpBinding CreateBindings()
                {
                    NetTcpBinding tcpBinding = new NetTcpBinding();
                    tcpBinding.Security.Mode = SecurityMode.None;
                    tcpBinding.Security.Mode = SecurityMode.Transport;
                    tcpBinding.CloseTimeout = TimeSpan.FromSeconds(1);
                    tcpBinding.OpenTimeout = TimeSpan.FromSeconds(2);
                    tcpBinding.ReceiveTimeout = TimeSpan.FromSeconds(15);
                    tcpBinding.SendTimeout = TimeSpan.FromSeconds(15);
                    return tcpBinding;
                }
                void Channel_Faulted(object sender, EventArgs e)
                {
                    Console.WriteLine("Channel faulted!!!");
                }
                [Obsolete("This method used only for callback", true)]
                public void Authenticate(bool authenticated)
                {
                    Console.WriteLine("authenticated: {0}", authenticated);
                }
                public void Login(string email, string password)
                {
                    _service.Login(email, password);
                }
                public void Logout(string email)
                {
                    _service.Logout(email);
                }
            }
            static void Main(string[] args)
            {
                // args[0] contains mode: server or client
                if (args[0] == "server"){
                    RunServer("localhost:42424");
                }
                else if (args[0] == "client"){
                    RunClient("localhost:42424");
                }
                else{
                    Console.WriteLine("Unknown mode. Only server or client");
                }
            }
    
            private static void RunClient(string cs)
            {
                // Create client for our servuce
                using (var client = new ServiceClient(cs))
                {
                    // Connect to it
                    client.Connect();
                    var fakeEmail = Guid.NewGuid().ToString();
                    // Call service methods (operation contracts)
                    client.Login(fakeEmail, fakeEmail);
                    Console.WriteLine("Invoked Login");
    
                    Console.WriteLine("Press 'Enter' to call Logout");
                    Console.ReadLine();
    
                    client.Logout(fakeEmail);
                    Console.WriteLine("Invoked Logout");
                }
            }
            static void RunServer(string cs)
            {
                var service = new Service();
    
                var sh = new ServiceHost(service, new Uri("net.tcp://" + cs));
                Console.WriteLine("ServiceHost created");
                try
                {
                    sh.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Couldn't open ServiceHost: {0}", ex);
                    return;
                }
                Console.WriteLine("ServiceHost opened");
                sh.Closed += ServiceHost_Closed;
                sh.Faulted += ServiceHost_Faulted;
    
                Console.WriteLine("Press 'Enter' to quit");
                Console.ReadLine();
            }
            private static void ServiceHost_Faulted(object sender, EventArgs e)
            {
                Console.WriteLine("ServiceHost faulted!!!");
            }
            private static void ServiceHost_Closed(object sender, EventArgs e)
            {
                Console.WriteLine("ServiceHost closed");
            }
        }
    }
