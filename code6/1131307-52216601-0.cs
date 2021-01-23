    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // What ever registrations you need here
            // IMessageService interacts with the hub
            builder.RegisterType<MessageService>().As<IMessageService>();
            // Register the controllers and the hubs
            builder.RegisterApiControllers(typeof(ServiceModule).Assembly);
            builder.RegisterHubs(typeof(ServiceModule).Assembly);
            // Register the default Assembly Locator since otherwise the hub will no be created by Signalr correctly IF it is NOT in the entry executables assembly.
            builder.RegisterType<DefaultAssemblyLocator>().As<IAssemblyLocator>();
            // Register Autofac resolver into container to be set into HubConfiguration later
            builder.RegisterType<Autofac.Integration.SignalR.AutofacDependencyResolver>()
                .As<Microsoft.AspNet.SignalR.IDependencyResolver>()
                .SingleInstance();
            // Register ConnectionManager as IConnectionManager so that you can get
            // hub context via IConnectionManager injected to your service
            builder.RegisterType<Microsoft.AspNet.SignalR.Infrastructure.ConnectionManager>()
                .As<Microsoft.AspNet.SignalR.Infrastructure.IConnectionManager>()
                .SingleInstance();
        }
    }
    public class Startup
    {
        /// <summary>
        /// Perform the configuration 
        /// </summary>
        /// <param name="app">The application builder to configure.</param>
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ServiceModule());
            var container = builder.Build();
            var config = new HttpConfiguration
            {
                DependencyResolver = new AutofacWebApiDependencyResolver(container),
    #if DEBUG
                IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always,
    #endif
            };
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
            var hubConfig = new HubConfiguration()
            {
    #if DEBUG
                EnableDetailedErrors = true,
    #endif
            };
            hubConfig.Resolver = container.Resolve<Microsoft.AspNet.SignalR.IDependencyResolver>();
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR("/signalr", hubConfig);
        }
    }
    public interface IMessageService
    {
        void BroadcastMessage(string message);
    }
    public class MessageService : IMessageService
    {
        private readonly IHubContext _hubContext;
        public MessageService(IConnectionManager connectionManager)
        {
            _hubContext = connectionManager.GetHubContext<MessageHub>();
        }
        public void BroadcastMessage(string message)
        {
            _hubContext.Clients.All.Message(message);
        }
    }
    public interface IMessage
    {
        void Message(string message);
    }
    public class MessageHub : Hub<IMessage>
    {
        private readonly ILifetimeScope _scope;
        public MessageHub(ILifetimeScope scope)
        {
            _scope = scope;
        }
        public void Message(string message)
        {
            Clients.Others.Message(message);
        }
        public override Task OnConnected()
        {
            Clients.Others.Message("Client connected: " + Context.ConnectionId);
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stoppedCalled)
        {
            Clients.Others.Message("Client disconnected: " + Context.ConnectionId);
            return base.OnDisconnected(stoppedCalled);
        }
    }
