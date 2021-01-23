    public class RRMessageProcessor : AMessageProcessor, IMessageProcessor<RRMessage> {
          public RRMessageProcessor(Controller controller) : base(controller) {}
    
          /* ----- REALLY DON'T WANT TO OVERRIDE THIS METHOD LIKE THIS EVERYWHERE --- */
          public override void Process(BaseMessage msg) {
                Process(msg as RRMessage);
            }
    
          public void Process(RRMessage msg) {
    
                //do something here
            }
        }
