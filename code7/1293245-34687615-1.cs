    // give an alias
    using Status = Order.OrderStatus;
    class SomeOtherClass
    {
        public void foo(){
            // reference is now simpler, rather than Order.OrderStatus.open
            Console.Write(Status.open);
        }
    }
