    //Handle<T> for any built-in type or something you create like MessageEvent etc.
    public class ViewModelB : Screen, IHandle<string>   
    {
       public ViewModelB(IEventAggregator events){
          _event = events;
          _events.Subscribe(this);
       }
       private void Handle(string t){
          MessageBox.Show(t);
       }
    }
    public class ViewModelA : Screen
    {
        private readonly IEventAggregator _event;
        public ViewModelA(IEventAggregator events)
        {
            _event = events;
            _event.Subscribe(this);
        }
     
        public void SomethingWasClicked()
        {
             _event.PublishOnUIThread("Hello, World!");
         }
    }
