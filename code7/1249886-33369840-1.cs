    public abstract class AbstractBaseClass<T>
        where T : AnotherAbstractClass
    {
        public abstract void Create(T param1);
    }
    
    public class ConcreteImplementation : AbstractBaseClass<AnotherConcreteImplementation>
    {
        public override void Create(AnotherConcreteImplementation param1)
        {
        }
    }
