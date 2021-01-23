        public class MessagePool
        {
            private static MessagePool theOnlyInstanceOfMessageBroker;
            private static object _syncRoot = new object();
        
            public static MessagePool GetInstance()
            {
                if (theOnlyInstanceOfMessageBroker == null)
                {   
                    lock(_syncRoot)
                    {
                        theOnlyInstanceOfMessageBroker = new MessagePool();
                    }
                }
                
                return theOnlyInstanceOfMessageBroker;
                
            }
        
            private MessagePool()
            {
            }
    
    //...
    }
