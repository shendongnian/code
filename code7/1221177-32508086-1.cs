    public class ViewModelA : Screen, IHandle<ShareMeMessageA>
    {
      private readonly IEventAggregator _events;
      private int _sharemecount;
      public class ViewModelA(IEventAggregator events){
       
           _events = events;
           _events.Subscribe(this);
      }
      //... other bits out for brevity 
      //-- EDIT -- 
      public void SomeEventClick(){
        _event.PublishOnUiThread(new ShareMeMessageB(){ ...  etc ... });
      }
      protected override void Deactivated(bool close){
        _events.Unsubscribe(this);
      }
      
      private void Handle(ShareMeMessageA msg)
      {
          if(msg != null)
            sharemecount = msg.Count;
      }
    }
