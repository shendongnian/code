    namespace MCWeb_3SR
    {
      public partial class Startup
      {
        public void ConfigureSignalR(IAppBuilder app) {
          var heartBeat = GlobalHost.DependencyResolver.Resolve<ITransportHeartbeat>(); 
    
          var monitor = new PresenceMonitor(heartBeat); 
          monitor.StartMonitoring(); 
    
    
          // Any connection or hub wire up and configuration should go here 
          app.MapSignalR();
        }
      }
    }
