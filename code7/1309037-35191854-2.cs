        private Subject<string> _messages = new Subject<string>();
        public IObservable<string> Messages { get { return _messages.AsObservable(); } }
        private Subject<bool> _isAutomateds = new Subject<bool>();
        public IObservable<bool> IsAutomateds { get { return _isAutomateds.AsObservable(); } }
        private SerialDisposable _serialSubscription = new SerialDisposable();
