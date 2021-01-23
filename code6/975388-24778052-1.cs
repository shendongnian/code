    public class MyViewModel
    {
        private State _state;
    
        public MyViewModel(IMyService myService)
        {
            myService.Status.ObserveOn(DispatcherScheduler.Current)
                .Subscribe(x =>
                            {
                                _state = x;
                            });
        }
    
        public bool IsReady { get { return _state == State.Initialized; } }
    }
