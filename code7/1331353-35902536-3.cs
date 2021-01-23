    class MyViewModel : MvxViewModel 
    {
        public MyViewModel(ITrackingService tracking)
        {
             tracking.CreateEvent(new GaEventMessage(this, "Event", "Publish Event", "Publish Event From First View Model", 123));
        }
    }
    
    // or
    class MyViewModel : MvxViewModel 
    {
        public MyViewModel()
        {
             var tracking = Mvx.Resolve<ITrackingService>();
             tracking.CreateEvent(new GaEventMessage(this, "Event", "Publish Event", "Publish Event From First View Model", 123));
        }
    }
