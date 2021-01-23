    _dispatcher = Dispatcher.CurrentDispatcher;
            _threadStart = delegate()
            {
                _dispatcher.BeginInvoke(new Action<object>(trial), DispatcherPriority.Normal, new object[] {this});
            };
    public void MultiThread()
        {
            _thread = new Thread(_threadStart) {Name = "MyApp - VM Worker"};
            _thread.Start();
        }
        void trial(object param)
        {
            this.Test = "Tested";
        }  
