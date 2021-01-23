    class Program
    {
        static void Main(string[] args) {
           var hasDoMethodInstance =  new HasDoMethodImpl();
           var hasDoMethodDecoratorInstance = new HasDoMethodDecorator(hasDoMethodInstance);
            hasDoMethodDecoratorInstance.Do();
        }
    }
    public interface IHasDoMethod
    {
        void Do();
    }
    public class HasDoMethodDecorator : IHasDoMethod
    {
        private int counter = 0;
        private readonly IHasDoMethod hasDoMethod;
        public HasDoMethodDecorator(IHasDoMethod hasDoMethod) {
            this.hasDoMethod = hasDoMethod;
        }
        public void Do() {
            hasDoMethod.Do();
            counter++;
        }
    }
    public class HasDoMethodImpl : IHasDoMethod
    {
        public void Do() {
            //Your logic
        }
    }
