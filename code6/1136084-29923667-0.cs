        public class MessagePool
        {
            private static MessagePool theOnlyInstanceOfMessageBroker;
        
            public static MessagePool GetInstance()
            {
                if (theOnlyInstanceOfMessageBroker == null)
                {
                    theOnlyInstanceOfMessageBroker = new MessagePool();
                }
                
                return theOnlyInstanceOfMessageBroker;
                
            }
        
            private MessagePool()
            {
            }
    
    //...
    }
