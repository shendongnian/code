    using System;
    using System.Diagnostics;
    using System.ServiceModel;
    using System.Threading;
    namespace Demo
    {
        [ServiceContract]
        interface IProgressReporter
        {
            [OperationContract]
            void ReportProgress(double percentComplete, string message);
        }
        [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
        sealed class Monitor: IProgressReporter
        {
            public void ReportProgress(double percentComplete, string message)
            {
                Console.WriteLine("Monitor received progress - Completed {0}%: {1}", percentComplete, message);
                if (percentComplete == 100)
                {
                    Program.ReportFinished();
                }
            }
        }
        public sealed class WcfServiceHost<T>: IDisposable where T: class
        {
            public WcfServiceHost(T service, string wcfEndpointAddress)
            {
                _service = service;
                _wcfEndpointAddress = wcfEndpointAddress;
                var serviceHost = new ServiceHost(service);
                serviceHost.AddServiceEndpoint(typeof(T), new NetNamedPipeBinding(), wcfEndpointAddress);
                serviceHost.Open();
                _serviceHost = serviceHost;
            }
            public T Service
            {
                get
                {
                    return _service;
                }
            }
            public string WcfEndpointAddress
            {
                get
                {
                    return _wcfEndpointAddress;
                }
            }
            /// <summary>Disposal.</summary>
            public void Dispose()
            {
                if (_serviceHost != null)
                {
                    try
                    {
                        _serviceHost.Close();
                    }
                    catch (Exception exception) // Don't allow exceptions to escape from Dispose().
                    {
                        Trace.WriteLine("There was an exception while closing the host: " + exception.Message);
                    }
                }
            }
            private readonly T _service;
            private readonly string _wcfEndpointAddress;
            private readonly ServiceHost _serviceHost;
        }
        public sealed class WcfServiceProxy<T>: IDisposable where T: class
        {
            public WcfServiceProxy(string wcfEndpointAddress)
            {
                _wcfEndpointAddress = wcfEndpointAddress;
                _channelFactory = new ChannelFactory<T>(new NetNamedPipeBinding(), _wcfEndpointAddress);
                _service = _channelFactory.CreateChannel();
                _comms = _service as ICommunicationObject;
                if (_comms == null)
                {
                    throw new InvalidOperationException("proxy does not implement ICommunicationObject.");
                }
            }
            public T Service
            {
                get
                {
                    return _service;
                }
            }
            public string WcfEndpointAddress
            {
                get
                {
                    return _wcfEndpointAddress;
                }
            }
            public void Dispose()
            {
                closeComms();
                closeChannelFactory();
            }
            private void closeComms()
            {
                try
                {
                    _comms.Close();
                }
                catch (CommunicationException exception) // Not closed - call Abort to transition to the closed state.
                {
                    Debug.WriteLine("CommunicationException while closing ICommunicationObject: " + exception.Message);
                    _comms.Abort();
                }
                catch (TimeoutException exception) // Not closed - call Abort to transition to the closed state.
                {
                    Debug.WriteLine("TimeoutException while closing ICommunicationObject: " + exception.Message);
                    _comms.Abort();
                }
                catch (Exception exception) // Not closed - call Abort to transition to the closed state.
                {
                    Trace.WriteLine("Unexpected exception while closing ICommunicationObject: " + exception.Message);
                    _comms.Abort();
                }
            }
            private void closeChannelFactory()
            {
                try
                {
                    _channelFactory.Close();
                }
                catch (CommunicationException exception) // Not closed - call Abort to transition to the closed state.
                {
                    Debug.WriteLine("CommunicationException while closing ChannelFactory: " + exception.Message);
                    _channelFactory.Abort();
                }
                catch (TimeoutException exception) // Not closed - call Abort to transition to the closed state.
                {
                    Debug.WriteLine("TimeoutException while closing ChannelFactory: " + exception.Message);
                    _channelFactory.Abort();
                }
                catch (Exception exception) // Not closed - call Abort to transition to the closed state.
                {
                    Trace.WriteLine("Unexpected exception while closing ChannelFactory: " + exception.Message);
                    _channelFactory.Abort();
                }
            }
            private readonly T _service;
            private readonly string _wcfEndpointAddress;
            private readonly ChannelFactory<T> _channelFactory;
            private readonly ICommunicationObject _comms;
        }
    
        internal static class Program
        {
            static void Main(string[] args)
            {
                if (args.Length > 0 && args[0] == "worker")
                    runWorker();
                else
                    runMonitor();
                Console.WriteLine("\nEnded. Press a key to exit.");
                Console.ReadKey();
            }
            public static void ReportFinished()
            {
                finished.Set();
            }
            static void runMonitor()
            {
                using (new WcfServiceHost<IProgressReporter>(new Monitor(), SERVICE_PIPE_NAME))
                {
                    finished.WaitOne();
                }
            }
            static void runWorker()
            {
                using (var proxy = new WcfServiceProxy<IProgressReporter>(SERVICE_PIPE_NAME))
                {
                    for (int i = 0; i <= 100; ++i)
                    {
                        Thread.Sleep(100);
                        Console.WriteLine("Worker reporting progress: Completed {0}%: {1}", i, i);
                        proxy.Service.ReportProgress(i, i.ToString());
                    }
                }
            }
            private static ManualResetEvent finished = new ManualResetEvent(false);
            private const string SERVICE_PIPE_NAME = "net.pipe://localhost/MyServicePipeName";
        }
    }
