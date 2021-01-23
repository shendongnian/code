        public interface ICallFlowApplication<T> where T : IChannel
        {
            void HandleCall(T channel);
        }
        
        public class TestCallFlowApplication : ICallFlowApplication<MySipChannel>
        {
            public void HandleCall(MySipChannel channel){}
        }
        
        public class MySipChannel : IChannel 
        {
            private SipChannel _channel;
            
            public MySipChannel(SipChannel channel)
            {
                _channel = channel;
            }
        }
        
        public interface IChannel {}
        public class SipChannel {}
