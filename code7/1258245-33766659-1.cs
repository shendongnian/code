    public class HeaderAwareBus : IHeaderAwareBus
    {
        private IBus _bus;
        private HeaderBucket _bucket;
        public HeaderAwareBus(IBus bus, HeaderBucket bucket)
        {
            _bus = bus;
            _bucket = bucket;
        }
        public ICallback Send(object message)
        {
            foreach (HeaderBucket.Header header in _bucket)
            {
                _bus.SetMessageHeader(message, header.Key, header.Value);
            }
            return _bus.Send(message);
        }
    }
