    interface IMessage
    {
        void CallSubscriberHandle(ISubscribe subscriber);
    }
    class StartMsg: IMessage
    {
        public void CallSubscriberHandle(ISubscribe subscr) { subscr.Handle(this); }
    }
    class ProgressMsg: IMessage
    {
        public void CallSubscriberHandle(ISubscribe subscr) { subscr.Handle(this); }
    }
    class EndMsg: IMessage
    {
        public void CallSubscriberHandle(ISubscribe subscr) { subscr.Handle(this); }
    }
