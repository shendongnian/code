    public struct Wrapper {
        public readonly CallContext CallContext;
        public readonly object Message;
        ...
    }
    public abstract class ContextualActor : ReceiveActor {
        protected CallContext CallContext;
        protected override bool AroundReceive(Receive receive, object message) {
            if (message is Wrapper) {
                var wrapped = (Wrapper)message;
                CallContext = wrapped.CallContext;
                return base.AroundReceive(receive, wrapped.Message);
            }
            else return base.AroundReceive(receive, message);
        }
        public void Send(IActorRef aref, object message) => 
            aref.Tell(new Wrapper(CallContext, message))
    }
