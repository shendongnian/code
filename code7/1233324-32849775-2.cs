    public interface IAlgorithmVisitor<X>
    {
        public X Visit(IBase data);
        public X Visit(ConcreteSubclass data);
        public X Visit(ConcreteOtherClass data);
    }
    public interface IAlgorithmVisitable<X>
    {
        X Accept(IAlgorithmVisitor<X> visitor);
    }
