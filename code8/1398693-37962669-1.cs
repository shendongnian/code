    public class SrvServiceCallbackProxy : ISrvServiceCallback
      {
    
        public event EventHandler PingReplyReceived;
    
        private SrvServiceClient _innerClient;
    
        private SrvServiceCallbackProxy() {
          var instanceContext = new System.ServiceModel.InstanceContext(this);
          _innerClient = new SrvService.SrvServiceClient(instanceContext);
         
        }
    
        private static SrvServiceCallbackProxy _instance;
        public static SrvServiceCallbackProxy Instance => _instance ?? (_instance = new SrvServiceCallbackProxy());
    
    
        public void PingReply(string reply) {
          this.PingReplyReceived?.Invoke(reply, EventArgs.Empty);
        }
    }
