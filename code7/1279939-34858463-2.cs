    using System;
    using System.Collections.ObjectModel;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    
    namespace ConsoleHost
    {
        class Program
        {
            static void Main(string[] args)
            {
                var logger = new DummyLogger();
                var errorHandler = new TestErrorHandler(logger);
    
                ServiceHost host = new TestServiceHost(errorHandler, typeof(TestService), new Uri("net.tcp://localhost:8002"));
                host.Open();
    
                Console.WriteLine("Press enter to exit");
                Console.ReadKey();
            }
        }
    
        [ServiceContract]
        public interface ITestService
        {
            [OperationContract]
            string Test(int input);
        }
    
        public class TestService : ITestService
        {
            public string Test(int input)
            {
                throw new Exception("Test exception!");
            }
        }
    
        public class TestErrorHandler : IErrorHandler
        {
            private ILogger Logger { get; }
    
            public TestErrorHandler(ILogger logger)
            {
                Logger = logger;
            }
    
            public bool HandleError(Exception error)
            {
                Logger.Log(error.Message);
                return true;
            }
    
            public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
            {
                FaultException fe = new FaultException();
                MessageFault message = fe.CreateMessageFault();
                fault = Message.CreateMessage(version, message, null);
            }
        }
    
        public class TestServiceHost : ServiceHost
        {
            private readonly IErrorHandler errorHandler;
    
            public TestServiceHost(IErrorHandler errorHandler, Type serviceType, params Uri[] baseAddresses)
                : base(serviceType, baseAddresses)
            {
                this.errorHandler = errorHandler;
            }
    
            protected override void OnOpening()
            {
                Description.Behaviors.Add(new ErrorHandlerBehaviour(errorHandler));
                base.OnOpening();
            }
    
            class ErrorHandlerBehaviour : IServiceBehavior, IErrorHandler
            {
                private readonly IErrorHandler errorHandler;
    
                public ErrorHandlerBehaviour(IErrorHandler errorHandler)
                {
                    this.errorHandler = errorHandler;
                }
    
                bool IErrorHandler.HandleError(Exception error)
                {
                    return errorHandler.HandleError(error);
                }
    
                void IErrorHandler.ProvideFault(Exception error, MessageVersion version, ref Message fault)
                {
                    errorHandler.ProvideFault(error, version, ref fault);
                }
    
                void IServiceBehavior.ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
                {
                    foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
                    {
                        channelDispatcher.ErrorHandlers.Add(this);
                    }
                }
    
                void IServiceBehavior.AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
                {
                }
    
                void IServiceBehavior.Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
                {
                }
            }
        }
    
        // Dummy logger
        public interface ILogger
        {
            void Log(string input);
        }
    
        public class DummyLogger : ILogger
        {
            public void Log(string input) => Console.WriteLine(input);
        }
    }
