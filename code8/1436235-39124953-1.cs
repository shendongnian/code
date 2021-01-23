    public class Listener
    {
        private ToBeListened toBeListenedObject = new ToBeListened();
        PropertyChangedHandler handler;
        public Listener()
        {
            handler = new PropertyChangedHandler(toBeListenedObject)
                        {
                            { "PropertyA", DoA },
                            { "PropertyB", DoB }
                        };
        }
        private void DoB()
        {            
        }
        private void DoA()
        {            
        }
    }
