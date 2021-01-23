    public class MyEvent {
       public MyClass Recipient { get; set; }
    }
    
    public class MyClass {
       public MyClass(IEventAggregator evt) {
          evt.Register<MyEvent>(TakeAction);
       }
       private void TakeAction(MyEvent event) {
          if (!event.Recipient == this) {
             return;
          }
          // Perform the action
       }
    }
