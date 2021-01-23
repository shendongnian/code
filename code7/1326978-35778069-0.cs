    public abstract class AMessageProcessor : IMessageProcessor<BaseMessage>
    
            protected Controller Controller { get; private set; }
    
            public AMessageProcessor(Controller controller) {
                Controller = controller;
            }
    
            /* ----- REALLY DON'T WANT TO OVERRIDE THIS METHOD EVERYWHERE --- */
            public abstract void Process(BaseMessage msg);
        }
