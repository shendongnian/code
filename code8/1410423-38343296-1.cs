    public class TracingAspect : IMessageSink
    {
        public TracingAspect(IMessageSink next)
        {
            m_next = next;
        }
