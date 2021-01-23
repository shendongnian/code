      string ns = "TcpEchoThreadServerLibrary.";
    
                TcpListener listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                ILogger logger = new ConsoleLogger();
    
                System.Runtime.Remoting.ObjectHandle objHandle =
                    Activator.CreateInstance("TcpEchoThreadServerLib", ns + protocolName + "ProtocolFactory");
                IProtocolFactory protocolFactory = (IProtocolFactory)objHandle.Unwrap();
    
                objHandle = Activator.CreateInstance("TcpEchoThreadServerLib", ns + dispatcherName + "Dispatcher");
                IDispatcher dispatcher = (IDispatcher)objHandle.Unwrap();
    
                dispatcher.startDispatching(listener, logger, protocolFactory);
