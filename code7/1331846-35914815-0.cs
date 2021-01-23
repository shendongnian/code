    public class ValueListManager
    {
        private class Ops : Operations
        {
            public Ops()
            {
            }
    
            public void Call()
            {
            }
        }
        
        public static Operations myOps { get { return new Ops(); } }
    }
