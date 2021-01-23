    using System;
    
    namespace MockProp
    {
       // This is my sketch of the API you've been given.
        public class MockProp
        {
           // I'm assuming that the API publishes the event handler's signature.
           public delegate void MockPropEventHandler(object sender, EventArgs args);
    
           // I'm assuming that the API's event is instance-based and not static.
           private event MockPropEventHandler MockPropEvent;
    
           // I'm assuming that it's keeping a reference to your event handler.
           private MockPropEventHandler clientHandler;
    
           public MockProp(MockPropEventHandler eventHandler)
           {
              this.clientHandler = eventHandler;
    
              // I'm assuming that it also auto-subscribes to the event because it is a constructor parameter.
              this.MockPropEvent += this.clientHandler;
           }
    
           // Provide an easy way for LabVIEW to trigger the event for demonstration purposes.
           public void NotifyEvent()
           {
              if (this.MockPropEvent != null)
              {
                 var args = new EventArgs();
                 this.MockPropEvent(sender: this, args: args);
              }
           }
    
           // Allow the object to be garbage collected by removing all retaining references.
           public void Release()
           {
              this.MockPropEvent -= this.clientHandler;
              this.clientHandler = null;
           }
        }
    
       // Here's one way to allow LabVIEW to subscribe to and handle private events
       public class MockPropAdapter
       {
          private MockProp mockProp;
    
          public MockPropAdapter()
          {
             // NOOP
          }
    
          // LabVIEW can subscribe to this event.
          public event MockProp.MockPropEventHandler MockPropEventRepeater;
    
          public MockProp CreateMockProp()
          {
             if (this.MockPropEventRepeater == null)
             {
                throw new InvalidOperationException(message:
                   "Subscribe to MockPropEventRepeater first. Otherwise, the Prop's event cannot be repeated.");
             }
             else
             {
                this.mockProp = new MockProp(eventHandler: this.MockPropEventRepeater);
                return this.mockProp;
             }
          }
    
          private void RepeatMockPropEvent(object sender, EventArgs args)
          {
             if (this.MockPropEventRepeater != null)
             {
                this.MockPropEventRepeater(sender, args);
             }
          }
       }
    }
