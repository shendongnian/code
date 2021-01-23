    public class ViewModelA : Screen, IHandle<ShareMeMessage>
    {
      private readonly IEventAggregator _events;
      private int _sharemecount;
      public class ViewModelA(IEventAggregator events){
       
           _events = events;
           _events.Subscribe(this);
      }
      //... other bits out for brevity 
      
      protected override void Deactivated(bool close){
        _events.Unsubscribe(this);
      }
      
      private void Handle(ShareMeMessage msg)
      {
          if(msg != null)
            sharemecount = msg.Count;
      }
    }
