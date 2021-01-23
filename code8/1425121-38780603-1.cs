    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var customerType = CustomerType.Library;
                var order = (Order)Activator.CreateInstance("ConsoleApplication2", "ConsoleApplication2." + customerType.ToString() + "Order").Unwrap();
            }
        }
    
        public enum CustomerType
        {
            Trade,
            Library
        }
    
        public abstract class Order
        {
            public virtual void Export() { }
        }
    
        public class TradeOrder : Order
        {
            public override void Export() { }
        }
    
        public class LibraryOrder : Order
        {
            public override void Export() { }
        }
    }
