        public interface ICallFlowApplication<T> where T : IChannel
        {
            void HandleCall(T channel);
        }
        
        public class TestCallFlowApplication : ICallFlowApplication<SipChannel>
        {
           public void HandleCall(SipChannel channel){}
        }
        
        public class SipChannel : IChannel {}
        public interface IChannel {}
