    public enum OrderStatus 
    { 
       open, 
       cancelled, 
       onHold 
    }
    
    class SomeOtherClass
    {
        private OrderStatus Status;
    
        public void foo(){
            // so the reference is simpler, rather than Order.OrderStatus.open
            Console.Write(Status.open);
        }
    }
