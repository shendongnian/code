      //Your Listener who has a public eventhandler where others can add them as listeners
      public class Listener{
          //your eventhandler where others "add" them as listeners
          public event EventHandler<PayLoadEventsArgs> IncomingPayload;
          
          //a method where you process new data and want to notify the others
          public void PushIncomingPayLoad(IPayload payload)
          {
              //check if there are any listeners
              if(IncomingPayload != null)
                  //if so, then notify them with the data in the PayloadEventArgs
                  IncomingPayload(this, new PayloadEventArgs(payload));
          }
      }  
      //Your EventArgs class to hold the data
      public class PayloadEventArgs : EventArgs{
          Payload payload { get; private set; }  
          public PayloadEventArgs(Payload payload){
              this.payload = payload;
          }
      }
      public class Worker{
          //add this instance as a observer
          YourListenerInstance.IncomingPayload += DoWork;
          
          //remove this instance 
          YourListenerInstance.IncomingPayload -= DoWork;
          //This method gets called when the Listener notifies the  IncomingPayload listeners
          void DoWork(Object sender, PayloadEventArgs e){
              Console.WriteLine(e.payload);
          }
       }
      
