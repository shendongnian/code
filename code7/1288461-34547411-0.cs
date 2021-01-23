    public class HandlerHelper<T> where T : EventArgs
    {
        private readonly EventHandler m_HandlerToCall;
        public HandlerHelper(EventHandler handler_to_call)
        {
            m_HandlerToCall = handler_to_call;
        }
        public void Handle(object sender, T args)
        {
            m_HandlerToCall.Invoke(sender, args);
        }
    }
