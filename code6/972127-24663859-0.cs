    class AsyncEventNotifier
    {
        private List<EventListener> _listeners;
        public void AddEventListener(EventListener listener) { _listeners.add(listener); }
        public void NotifyListeners(EventArgs args)
        {
            // spawn a new thread to call the listener methods
        }
        ....
    }
        
    class EventGeneratingClass
    {
        private AsyncEventHandler _asyncEventHandler;
        public void AddEventListener(EventListener listener) { _asyncEventHandler.AddEventListener(listener); }
        
        private void FireSomeEvent()
        {
            var eventArgs = new EventArgs();
            ...
            _asyncEventhandler.NotifyListeners(eventArgs);
        }
    }
