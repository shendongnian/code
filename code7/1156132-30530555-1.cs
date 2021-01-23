    abstract class AbstractClass
    {
        public abstract void AbstractMethodA();
        public void ConcreteMethodA()
        {
            Helper.ConcreteMethodB(AbstractMethodA);
        }
    }
