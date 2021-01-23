    using AngleSharp.Events;
    // ...
    class SimpleEventAggregator : IEventAggregator
    {
        readonly List<HtmlParseErrorEvent> _errors = new List<HtmlParseErrorEvent>();
        public void Publish<TEvent>(TEvent data)
        {
            var error = data as HtmlParseErrorEvent;
            if (error != null)
                _errors.Add(error);
        }
        public List<HtmlParseErrorEvent> Errors
        {
            get { return _errors; }
        }
        public void Subscribe<TEvent>(ISubscriber<TEvent> listener) { }
        public void Unsubscribe<TEvent>(ISubscriber<TEvent> listener) { }
    }
