        public class FluentExample : ICanCallAB
        {
            public ICanCallB A()
            {
                return this;
            }
    
            public ICanCallAB B()
            {
                return this;
            }
        }
    
        public interface ICanCallA
        {
            void A();
        }
    
        public interface ICanCallAB : ICanCallA
        {
            void B();
        }
    Of course, a consumer could get around this using casting or `dynamic`, but at least in this case the class can state its own intent.
